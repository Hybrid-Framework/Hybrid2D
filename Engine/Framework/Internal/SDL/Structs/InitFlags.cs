using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [Flags]
    public enum InitFlags : uint
    {
        Timer = 0x00000001,
        Audio = 0x00000010,
        Video = 0x00000020,
        Gamepad = 0x00002000,
        Joystick = 0x00000200,
        Everything = (Timer | Audio | Video | Gamepad | Joystick)
    }
}