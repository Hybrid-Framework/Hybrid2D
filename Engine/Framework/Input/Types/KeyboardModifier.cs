using System;

namespace Hybrid
{
    [Flags]
    public enum KeyboardModifier : ushort
    {
        None = 0,
        
        LeftShift = 0x0001,
        RightShift = 0x0002,
        LeftControl = 0x0040,
        RightControl = 0x0080,
        LeftAlt = 0x0100,
        RightAlt = 0x0200,
        NumLock = 0x1000,
        CapLock = 0x2000,
        ScrollLock = 0x8000,
    }
}