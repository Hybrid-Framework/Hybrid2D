using System.Globalization;
using System;

namespace Hybrid
{
    internal unsafe class InputText : InputDevice
    {
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
        
        internal void StartTextInput(KeyboardInputType inputType = KeyboardInputType.AlphaNumeric, int limit = 0)
        {
            // Reset
            ResetText();
            
            // Properties
            var properties = SDL.CreateProperties();
            SDL.SetNumberProperty(properties, SDL.Properties.Text_InputType, (long)(SDL.TextInputType)inputType);
            SDL.StartTextInputWithProperties(Window.Handle, properties);
            SDL.DestroyProperties(properties);

            // Settings
            Limit = limit;
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
                    Text += input;
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

                    Text += input;
                }
            }
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
            Text = string.Empty;
            Limit = 0;
        }
    }
}