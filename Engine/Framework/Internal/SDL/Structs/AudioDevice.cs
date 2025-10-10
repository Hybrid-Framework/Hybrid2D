using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    public enum AudioDevice : uint
    {
        Playback = 0xFFFFFFFF,
        Recording = 0xFFFFFFFE,
    }
}