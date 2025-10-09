using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [Flags]
    public enum KeyModifier : ushort
    {
        None = 0x0000,
        
        LeftShift = 0x0001,
        RightShift = 0x0002,
        LeftControl = 0x0040,
        RightControl = 0x0080,
        LeftAlt = 0x0100,
        RightAlt = 0x0200,
        
        CTRL = LeftControl | RightControl,
        SHIFT = LeftShift | RightShift,
        ALT = LeftAlt | RightAlt,
    }
}