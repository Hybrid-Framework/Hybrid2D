using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct JoystickBallEvent
    {
        internal SDL.EventType type;
        internal uint reserved;
        internal ulong timestamp;
        internal uint joystickID;
        internal byte ball;
        private byte padding1;
        private byte padding2;
        private byte padding3;
        internal short x_relative;
        internal short y_relative;
    }
}