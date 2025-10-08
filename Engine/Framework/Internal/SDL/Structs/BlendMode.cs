using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [Flags]
    public enum BlendMode : uint
    {
        None = 0x00000000,
        Blend = 0x00000001,
        BlendPremultiplied = 0x00000010,
        Add = 0x00000002,
        AddPremultiplied = 0x00000020,
        Modulate = 0x00000004,
        Multiply = 0x00000008,
        Invalid = 0x7FFFFFFF
    }
}