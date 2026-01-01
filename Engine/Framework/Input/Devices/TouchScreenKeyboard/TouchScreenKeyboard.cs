using System.Globalization;
using System;

namespace Hybrid
{
    public unsafe partial class TouchScreenKeyboard : InputDevice
    {
        internal override void OnDispose()
        {
            Close();
        }

        internal override void OnEvent(SDL.Event e)
        {
            switch (e.type)
            {
                // Hide Keyboard
                case SDL.EventType.OnScreenKeyboardHidden:
                {
                    Reset();
                    break;
                }
                
                // Text Input
                case SDL.EventType.TextInput:
                {
                    Append(SDL.Utf8ToString(e.textInput.text));
                    break;
                }
                
                // Keyboard
                case SDL.EventType.KeyboardButtonDown:
                {
                    switch (e.keyboard.keyCode)
                    {
                        // Backspace
                        case SDL.KeyCode.Backspace:
                        {
                            Remove();
                            break;
                        }
                        
                        // Enter
                        case SDL.KeyCode.Return:
                        {
                            Close();
                            break;
                        }
                    }
                    
                    break;
                }
            }
        }
    }

    public unsafe partial class TouchScreenKeyboard
    {
        public static string DisplayText
        {
            get
            {
                if (Type == TouchScreenKeyboardType.Password)
                {
                    return new string('*', Text.Length);
                }

                return Text;
            }
        }
        
        public static TouchScreenKeyboardType Type
        {
            private set;
            get;
        }
        
        public static int MaxCharacters
        {
            private set;
            get;
        }
        
        public static string Text
        {
            private set;
            get;
        }
        
        public static void Open(TouchScreenKeyboardType type = TouchScreenKeyboardType.Default, bool autocorrect = false, int maxCharacters = 0)
        {
            if (IsSupported())
            {
                Close();
            
                // Properties
                var properties = SDL.CreateProperties();
                SDL.SetNumberProperty(properties, SDL.Properties.Text_InputType, (long)(SDL.TextInputType)type);
                SDL.SetBooleanProperty(properties, SDL.Properties.Text_InputAutocorrect, autocorrect);

                // Start Text Input
                SDL.StartTextInputWithProperties(Window.Handle, properties);
                SDL.DestroyProperties(properties);

                // Settings
                MaxCharacters = maxCharacters;
                Type = type;
            }
        }

        public static bool IsSupported()
        {
            return SDL.HasScreenKeyboardSupport();
        }

        public static bool Visible()
        {
            if (IsSupported())
            {
                return SDL.ScreenKeyboardShown(Window.Handle);
            }

            return false;
        }

        public static void Close()
        {
            if (IsSupported())
            {
                SDL.StopTextInput(Window.Handle);
                {
                    Reset();
                }
            }
        }
        
        private static void Append(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                if (MaxCharacters == 0)
                {
                    Text += input;
                    return;
                }

                var textInfo  = new StringInfo(Text);
                var inputInfo = new StringInfo(input);

                int current = textInfo.LengthInTextElements;
                int remaining = MaxCharacters - current;

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

        private static void Remove()
        {
            if (!string.IsNullOrEmpty(Text))
            {
                var info = new StringInfo(Text);
                {
                    Text = info.SubstringByTextElements(0, info.LengthInTextElements - 1);
                }
            }
        }
        
        private static void Reset()
        {
            Type = TouchScreenKeyboardType.Default;
            Text = string.Empty;
            MaxCharacters = 0;
        }
    }
}