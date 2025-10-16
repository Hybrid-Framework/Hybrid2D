using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    public enum TouchDeviceType
    {
        Invalid = -1,
        Direct = 0,
        IndirectAbsolute = 1,
        IndirectRelative = 2,
    }
}