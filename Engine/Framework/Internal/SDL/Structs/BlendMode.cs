using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    public enum BlendMode : uint
    {
        None = 0x00000000,
        AlphaBlend = 0x00000001,
        AlphaBlendPremultiplied = 0x00000010,
        Additive = 0x00000002,
        AdditivePremultiplied = 0x00000020,
        ColorModulate = 0x00000004,
        ColorMultiply = 0x00000008,
        Invalid = 0x7FFFFFFF
    }
}