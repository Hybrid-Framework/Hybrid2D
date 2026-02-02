using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    internal enum PropertyType
    {
        Invalid = 0,
        Pointer = 1,
        String = 2,
        Number = 3,
        Float = 4,
        Boolean = 5,
    }
}