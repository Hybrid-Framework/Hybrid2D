using System.Runtime.InteropServices;
using System;

internal static unsafe partial class SDL
{
    [Flags]
    internal enum MouseButtonFlags : uint
    {
        Left   = 1u << (1 - 1),
        Middle = 1u << (2 - 1),
        Right  = 1u << (3 - 1),
    }
}