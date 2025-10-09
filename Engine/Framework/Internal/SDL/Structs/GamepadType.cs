using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    public enum GamepadType
    {
        Unknown = 0,
        Standard = 1,
        Xbox360 = 2,
        XboxOne = 3,
        PlayStation3 = 4,
        PlayStation4 = 5,
        PlayStation5 = 6,
        NintendoSwitchPro = 7,
        NintendoSwitchJoyconLeft = 8,
        NintendoSwitchJoyconRight = 9,
        NintendoSwitchPair = 10,
    }
}