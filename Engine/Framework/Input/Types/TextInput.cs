using System.Globalization;
using System.Text;
using System;

namespace Hybrid
{
    internal unsafe class TextInput : InputDevice
    {
        internal TextInputMode Mode { get; private set; } = TextInputMode.Default;
        internal string Text { get; private set; } = string.Empty;
        internal int Limit { get; private set; }


        internal override void OnEvent(SDL.Event e)
        {
            switch (e.type)
            {
                // Text Input
                case SDL.EventType.TextInput:
                {
                    AppendText(SDL.Utf8ToString(e.textInput.text));
                    break;
                }
                
                // Text Input Functions
                case SDL.EventType.KeyboardButtonDown:
                {
                    switch (e.keyboard.keyCode)
                    {
                        // Backspace
                        case SDL.KeyCode.Backspace:
                        {
                            RemoveText();
                            break;
                        }
                        
                        // Enter
                        case SDL.KeyCode.Return:
                        {
                            if (TouchScreenKeyboard.IsVisible())
                            {
                                StopTextInput();
                            }
                            
                            break;
                        }
                    }
                    
                    break;
                }
            }
        }
        
        internal void StartTextInput(TextInputMode mode = TextInputMode.Default, int limit = 0)
        {
            // Reset
            ResetText();

            // SDL Keyboard Type
            SDL.TextInputType type = mode switch
            {
                TextInputMode.Default => SDL.TextInputType.Default,
                TextInputMode.Alpha => SDL.TextInputType.AlphaNumericSymbol,
                TextInputMode.AlphaNumeric => SDL.TextInputType.AlphaNumericSymbol,
                TextInputMode.AlphaNumericSymbol => SDL.TextInputType.AlphaNumericSymbol,
                TextInputMode.Symbols => SDL.TextInputType.AlphaNumericSymbol,
                TextInputMode.Numeric => SDL.TextInputType.Numeric,
                TextInputMode.Email => SDL.TextInputType.EmailOrURL,
                TextInputMode.Username => SDL.TextInputType.AlphaNumericSymbol,
                TextInputMode.Password => SDL.TextInputType.AlphaNumericSymbol,
                TextInputMode.Url => SDL.TextInputType.EmailOrURL,
                
                _ => SDL.TextInputType.Default
            };
            
            // Properties
            var properties = SDL.CreateProperties();
            SDL.SetNumberProperty(properties, SDL.Properties.Text_InputType, (long)type);
            SDL.StartTextInputWithProperties(Window.Handle, properties);
            SDL.DestroyProperties(properties);

            // Settings
            Limit = limit;
            Mode = mode;
        }
        
        internal void StopTextInput()
        {
            SDL.StopTextInput(Window.Handle);
            {
                ResetText();
            }
        }
        
        private void AppendText(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                if (Limit == 0)
                {
                    Text += FilterText(input);
                    return;
                }

                var textInfo  = new StringInfo(Text);
                var inputInfo = new StringInfo(input);

                int current = textInfo.LengthInTextElements;
                int remaining = Limit - current;

                if (remaining > 0)
                {
                    if (inputInfo.LengthInTextElements > remaining)
                    {
                        input = inputInfo.SubstringByTextElements(0, remaining);
                    }

                    input = FilterText(input);
                    Text += input;
                }
            }
        }
        
        private string FilterText(string input)
        {
            var textInfo = new StringBuilder();
            var inputInfo = new StringInfo(input);

            for (int i = 0; i < inputInfo.LengthInTextElements; i++)
            {
                var element = inputInfo.SubstringByTextElements(i, 1);
                var c = element[0];
                
                bool allowed = Mode switch
                {
                    TextInputMode.Default => true,
                    TextInputMode.Password => true,
                    TextInputMode.Alpha => char.IsLetter(c) || char.IsWhiteSpace(c),
                    TextInputMode.Symbols => char.IsSymbol(c) || char.IsPunctuation(c),
                    TextInputMode.AlphaNumeric => char.IsLetter(c) || char.IsNumber(c) || char.IsWhiteSpace(c),
                    TextInputMode.AlphaNumericSymbol => char.IsLetter(c) || char.IsNumber(c) || char.IsSymbol(c) || char.IsPunctuation(c) || char.IsWhiteSpace(c),
                    TextInputMode.Numeric => char.IsNumber(c) || "-.,".Contains(c),
                    TextInputMode.Email => char.IsNumber(c) || char.IsLetter(c) || "@._+-".Contains(c),
                    TextInputMode.Username => char.IsLetter(c) || char.IsNumber(c) || "_-".Contains(c),
                    TextInputMode.Url => char.IsLetter(c) || char.IsNumber(c) || "-_.~:/?#[]@!$&'()*+,;=".Contains(c),
                    
                    _ => true
                };
                
                if (allowed)
                {
                    textInfo.Append(element);
                }
            }

            return textInfo.ToString();
        }

        private void RemoveText()
        {
            if (!string.IsNullOrEmpty(Text))
            {
                var info = new StringInfo(Text);
                {
                    Text = info.SubstringByTextElements(0, info.LengthInTextElements - 1);
                }
            }
        }
        
        private void ResetText()
        {
            Mode = TextInputMode.Default;
            Text = string.Empty;
            Limit = 0;
        }
    }
}