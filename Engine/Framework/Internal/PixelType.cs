using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    public enum PixelType
    {
        UNKNOWN = 0,
        INDEX1 = 1,
        INDEX4 = 2,
        INDEX8 = 3,
        PACKED8 = 4,
        PACKED16 = 5,
        PACKED32 = 6,
        ARRAYU8 = 7,
        ARRAYU16 = 8,
        ARRAYU32 = 9,
        ARRAYF16 = 10,
        ARRAYF32 = 11,
        INDEX2 = 12,
    }
}