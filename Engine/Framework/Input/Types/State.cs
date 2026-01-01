using System;

namespace Hybrid
{
    [Flags]
    internal enum State
    {
        None    = 0,
        Down    = 1 << 0,
        Hold    = 1 << 1,
        Release = 1 << 2,
    }
}