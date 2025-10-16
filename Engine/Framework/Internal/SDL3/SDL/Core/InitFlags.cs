using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [Flags]
    public enum InitFlags : uint
    {
        Timer = 0x1,
        Audio = 0x10,
        Video = 0x20,
        Gamepad = 0x2000,
        Everything = (Timer | Audio | Video | Gamepad)
    }
}