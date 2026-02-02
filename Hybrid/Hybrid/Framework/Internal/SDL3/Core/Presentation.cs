using System.Runtime.InteropServices;
using System;

internal static unsafe partial class SDL
{
    [Flags]
    internal enum Presentation
    {
        Disabled = 0,
        Stretch = 1,
        Letterbox = 2,
        Overscan = 3,
        IntegerScaled = 4,
    }
}