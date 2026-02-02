using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    internal enum TouchDeviceType
    {
        Invalid = -1,
        Direct = 0,
        IndirectAbsolute = 1,
        IndirectRelative = 2,
    }
}