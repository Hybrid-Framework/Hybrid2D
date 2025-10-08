using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [Flags]
    public enum WindowFlags : ulong
    {
        Fullscreen = 0x0000000000000001,
        Borderless = 0x0000000000000010,
        Resizeable = 0x0000000000000020,
        Minimised = 0x0000000000000040,
        Maximised = 0x0000000000000080,
        HighPixelDensity = 0x0000000000002000,
    }
}