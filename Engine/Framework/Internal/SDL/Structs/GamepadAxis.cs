using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    public enum GamepadAxis
    {
        Invalid = -1,
        LeftHorizontal = 0,
        LeftVertical = 1,
        RightHorizontal = 2,
        RightVertical = 3,
        LeftTrigger = 4,
        RightTrigger = 5,
    }
}