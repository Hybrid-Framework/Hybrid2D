using System.Runtime.InteropServices;
using System;

internal static unsafe partial class SDL_ttf
{
    [Flags]
    public enum FontStyle : uint
    {
        Normal = 0x00,
        Bold = 0x01,
        Italic = 0x02,
        Underline = 0x04,
        Strikethrough = 0x08,
    }
}