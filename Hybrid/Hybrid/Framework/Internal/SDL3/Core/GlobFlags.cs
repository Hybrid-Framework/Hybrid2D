using System.Runtime.InteropServices;
using System;

internal static unsafe partial class SDL
{
    [Flags]
    internal enum GlobFlags : uint
    {
        CaseSensitive = 0,
        CaseInsensitive = 0x1,
    }
}