using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [Flags]
    public enum WindowFlags : ulong
    {
        Fullscreen = 0x1,
        Resizable = 0x20,
        HighPixelDensity = 0x2000,
    }
}