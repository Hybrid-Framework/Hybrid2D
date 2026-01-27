using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    public enum PackedOrder
    {
        NONE = 0,
        XRGB = 1,
        RGBX = 2,
        ARGB = 3,
        RGBA = 4,
        XBGR = 5,
        BGRX = 6,
        ABGR = 7,
        BGRA = 8,
    }
}