using System;

namespace Hybrid
{
    public static unsafe class TouchScreenKeyboard
    {
        public static string Text => Input.TextInput.Text;
        
        
        public static void Open(TextInputMode mode = TextInputMode.Default, int limit = 0)
        {
            if (IsSupported())
            {
                Input.TextInput.TextInputStart(mode, limit);
            }
        }
        
        public static void Close()
        {
            if (IsSupported())
            {
                Input.TextInput.TextInputStop();
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