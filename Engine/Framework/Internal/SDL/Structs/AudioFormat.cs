using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    public enum AudioFormat : ushort
    {
        Unknown = 0,
        U8 = 0x0008,
        S8 = 0x8008,
        S16LE = 0x8010,
        S16BE = 0x9010,
        S32LE = 0x8020,
        S32BE = 0x9020,
        F32LE = 0x8120,
        F32BE = 0x9120,
        S16 = 0x8010,
        S32 = 0x8020,
        F32 = 0x8120
    }
}