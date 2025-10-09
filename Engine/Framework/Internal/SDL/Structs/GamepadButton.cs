using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    public enum GamepadButton
    {
        Invalid = -1,
        South = 0,
        East = 1,
        West = 2,
        North = 3,
        Back = 4,
        Start = 6,
        LeftStick = 7,
        RightStick = 8,
        LeftShoulder = 9,
        RightShoulder = 10,
        DpadUp = 11,
        DpadDown = 12,
        DpadLeft = 13,
        DpadRight = 14,
    }
}