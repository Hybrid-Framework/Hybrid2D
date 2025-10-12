using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [Flags]
    public enum WindowFlags : ulong
    {
        Fullscreen = 0x1,
        Borderless = 0x10,
        Resizable = 0x20,
        HighPixelDensity = 0x2000,
    }
}