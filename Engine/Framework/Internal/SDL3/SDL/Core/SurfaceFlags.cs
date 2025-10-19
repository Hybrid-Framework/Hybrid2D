using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [Flags]
    public enum SurfaceFlags : uint
    {
        Preallocated = 0x1,
        lockNeeded = 0x2,
        locked = 0x4,
        SIMDAligned = 0x08,
    }
}