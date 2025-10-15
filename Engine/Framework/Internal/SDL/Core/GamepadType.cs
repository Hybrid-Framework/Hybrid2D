using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    public enum GamepadType
    {
        Unknown = 0,
        Generic = 1,
        Xbox360 = 2,
        XboxOne = 3,
        PlayStation3 = 4,
        PlayStation4 = 5,
        PlayStation5 = 6,
        NintendoSwitch = 7,
        NintendoSwitchJoyConLeft = 8,
        NintendoSwitchJoyConRight = 9,
        NintendoSwitchJoyConPair = 10,
    }
}