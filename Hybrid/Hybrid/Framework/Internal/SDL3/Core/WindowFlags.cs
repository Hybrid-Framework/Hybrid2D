using System.Runtime.InteropServices;
using System;

internal static unsafe partial class SDL
{
    [Flags]
    internal enum WindowFlags : ulong
    {
        Fullscreen = 0x1,
        Hidden = 0x08,
        Borderless = 0x10,
        Resizable = 0x20,
        Minimized = 0x40,
        InputFocus = 0x200,
        MouseFocus = 0x400,
        Maximized = 0x080,
        HighPixelDensity = 0x2000,
    }
}