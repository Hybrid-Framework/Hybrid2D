using System;

namespace Hybrid
{
    public static class Clipboard
    {
        public static void SetClipboardText(string text)
        {
            SDL.SetClipboardText(text);
        }
        
        // Get clipboard text
        public static string GetClipboardText()
        {
            return SDL.GetClipboardText();
        }
    }
}