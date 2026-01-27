using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    public enum GamepadAxis : byte
    {
        LeftStickX = 0,
        LeftStickY = 1,
        LeftTrigger = 4,
        RightStickX = 2,
        RightStickY = 3,
        RightTrigger = 5,
    }
}