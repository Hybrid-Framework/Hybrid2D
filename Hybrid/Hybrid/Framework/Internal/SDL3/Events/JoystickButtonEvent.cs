using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct JoystickButtonEvent
    {
        internal SDL.EventType type;
        internal uint reserved;
        internal ulong timestamp;
        internal uint joystickID;
        internal byte button;
        internal SDL.Bool down;
        private byte padding1;
        private byte padding2;
    }
}