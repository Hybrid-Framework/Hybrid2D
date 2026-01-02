using System;

namespace Hybrid
{
    [Flags]
    internal enum KeyState
    {
        None    = 0,
        Down    = 1 << 0,
        Press   = 1 << 1,
        Release = 1 << 2,
    }
}