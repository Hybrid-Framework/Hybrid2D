using System;

namespace Hybrid
{
    public static class Clipboard
    {
        public static string Text
        {
            get => SDL.GetClipboardText();
            set => SDL.SetClipboardText(value);
        }
    }
}