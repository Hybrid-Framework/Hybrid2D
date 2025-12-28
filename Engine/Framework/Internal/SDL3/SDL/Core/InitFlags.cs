using System.Runtime.InteropServices;
using System;

internal static unsafe partial class SDL
{
    [Flags]
    public enum InitFlags : uint
    {
        Timer = 0x1,
        Audio = 0x10,
        Video = 0x20,
        Joystick = 0x200,
        Gamepad = 0x2000,
        Everything = (Timer | Audio | Video | Joystick | Gamepad)
    }
}