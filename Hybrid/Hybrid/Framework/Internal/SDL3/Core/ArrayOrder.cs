using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    public enum ArrayOrder
    {
        NONE = 0,
        RGB = 1,
        RGBA = 2,
        ARGB = 3,
        BGR = 4,
        BGRA = 5,
        ABGR = 6,
    }
}