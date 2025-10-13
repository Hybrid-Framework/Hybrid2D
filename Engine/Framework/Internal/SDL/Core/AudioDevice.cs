using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    public enum AudioDevice : uint
    {
        DefaultPlayback = 0xFFFFFFFFu,
        DefaultRecording = 0xFFFFFFFEu
    }
}