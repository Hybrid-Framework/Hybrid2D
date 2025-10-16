using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [Flags]
    public enum MouseButtonFlags : uint
    {
        LeftMask = 0x1,
        MiddleMask = 0x2,
        RightMask = 0x4,
    }
}