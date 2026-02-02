using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    internal enum JoystickConnectionState
    {
        Invalid = -1,
        Unknown = 0,
        Wired = 1,
        Wireless = 2,
    }
}