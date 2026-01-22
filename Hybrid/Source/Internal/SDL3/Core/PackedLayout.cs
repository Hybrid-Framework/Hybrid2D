using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    public enum PackedLayout
    {
        NONE = 0,
        LAYOUT_332 = 1,
        LAYOUT_4444 = 2,
        LAYOUT_1555 = 3,
        LAYOUT_5551 = 4,
        LAYOUT_565 = 5,
        LAYOUT_8888 = 6,
        LAYOUT_2101010 = 7,
        LAYOUT_1010102 = 8,
    }
}