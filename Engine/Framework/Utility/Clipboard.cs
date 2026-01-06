using System;

namespace Hybrid
{
    public static class Clipboard
    {
        public static void SetText(string text)
        {
            SDL.SetClipboardText(text);
        }
        
        public static string GetText()
        {
            return SDL.GetClipboardText();
        }
    }
}