using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    internal enum JoystickType
    {
        Unknown = 0,
        Gamepad = 1,
        Wheel = 2,
        ArcadeStick = 3,
        FlightStick = 4,
        DancePad = 5,
        Guitar = 6,
        DrumKit = 7,
        ArcadePad = 8,
        JoyStickThrottle = 9,
    }
}