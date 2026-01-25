using System.Globalization;
using System;

namespace Hybrid
{
    // Internal
    internal unsafe partial class TouchKeyboard : InputDevice
    {
        private static string TextHandle { get; set; } = string.Empty;
        
        
        internal override void OnEvent(SDL.Event e)
        {
            switch (e.type)
            {
                // Text Input
                case SDL.EventType.TextInput:
                {
                    Append(SDL.Utf8ToString(e.textInput.text));
                    break;
                }

                // Text Input Functions
                case SDL.EventType.KeyboardButtonDown:
                {
                    switch (e.keyboard.keyCode)
                    {
                        case SDL.KeyCode.Backspace:
                        {
                            Remove();
                            break;
                        }

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
        
        private static void Append(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                TextHandle += input;
            }
        }
        
        private static void Remove()
        {
            if (!string.IsNullOrEmpty(TextHandle))
            {
                var info = new StringInfo(TextHandle);
                {
                    TextHandle = info.SubstringByTextElements(0, info.LengthInTextElements - 1);
                }
            }
        }
    }

    // On Screen Keyboard API
    internal unsafe partial class TouchKeyboard
    {
        // Open screen keyboard
        internal void Open()
        {
            SDL.StartTextInput(Window.Handle);
        }

        // Close screen keyboard
        internal void Close()
        {
            SDL.StopTextInput(Window.Handle);
        }

        // Is screen keyboard visible
        internal bool IsVisible()
        {
            return SDL.ScreenKeyboardShown(Window.Handle);
        }
        
        // Is screen keyboard supported
        internal bool IsSupported()
        {
            return SDL.HasScreenKeyboardSupport();
        }
        
        // Get screen keyboard text
        internal string GetText()
        {
            return TextHandle;
        }
    }
}