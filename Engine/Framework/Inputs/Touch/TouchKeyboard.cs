using System.Globalization;
using System;

namespace Hybrid
{
    // Internal
    public sealed unsafe partial class TouchKeyboard : Module
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
    public unsafe partial class TouchKeyboard
    {
        // Open screen keyboard
        public static void Open()
        {
            SDL.StartTextInput(Window.Handle);
        }

        // Close screen keyboard
        public static void Close()
        {
            SDL.StopTextInput(Window.Handle);
        }

        // Is screen keyboard visible
        public static bool IsVisible()
        {
            return SDL.ScreenKeyboardShown(Window.Handle);
        }
        
        // Is screen keyboard supported
        public static bool IsSupported()
        {
            return SDL.HasScreenKeyboardSupport();
        }
        
        // Get screen keyboard text
        public static string GetText()
        {
            return TextHandle;
        }
    }
}