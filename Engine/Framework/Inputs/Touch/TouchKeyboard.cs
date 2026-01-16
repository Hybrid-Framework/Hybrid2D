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
        public static void Open()
        {
            SDL.StartTextInput(Window.Handle);
        }

        public static void Close()
        {
            SDL.StopTextInput(Window.Handle);
        }

        public static bool Visible()
        {
            return SDL.ScreenKeyboardShown(Window.Handle);
        }

        public static void Clear()
        {
            SDL.ClearComposition(Window.Handle);
            TextHandle = string.Empty;
        }
        
        public static string Text()
        {
            return TextHandle;
        }
    }
}