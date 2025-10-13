using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    public enum ColorSpace
    {
        UNKNOWN = 0,
        SRGB = 301991328,
        SRGB_LINEAR = 301991168,
        HDR10 = 301999616,
        JPEG = 570426566,
        BT601_LIMITED = 554703046,
        BT601_FULL = 571480262,
        BT709_LIMITED = 554697761,
        BT709_FULL = 571474977,
        BT2020_LIMITED = 554706441,
        BT2020_FULL = 571483657,
        RGB_DEFAULT = 301991328,
        YUV_DEFAULT = 570426566,
    }
}