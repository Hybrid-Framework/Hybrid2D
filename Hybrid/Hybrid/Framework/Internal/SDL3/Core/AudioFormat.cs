using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    internal enum AudioFormat
    {
        Unknown = 0,
        U8 = 8,
        S8 = 32776,
        S16LE = 32784,
        S16BE = 36880,
        S32LE = 32800,
        S32BE = 36896,
        F32LE = 33056,
        F32BE = 37152,
        S16 = 32784,
        S32 = 32800,
        F32 = 33056,
    }
}