using System;

namespace Hybrid
{
    public static unsafe class TouchScreenKeyboard
    {
        public static string Text => Input.InputText.Text;
        
        
        public static void Open(KeyboardInputType type = KeyboardInputType.AlphaNumeric, int limit = 0)
        {
            if (IsSupported())
            {
                Input.InputText.StartTextInput(type, limit);
            }
        }
        
        public static void Close()
        {
            if (IsSupported())
            {
                Input.InputText.StopTextInput();
            }
        }
        
        public static bool IsSupported()
        {
            return SDL.HasScreenKeyboardSupport();
        }

        public static bool IsVisible()
        {
            return SDL.ScreenKeyboardShown(Window.Handle);
        }
    }
}