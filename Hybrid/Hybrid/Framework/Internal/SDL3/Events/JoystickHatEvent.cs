using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct JoystickHatEvent
    {
        internal SDL.EventType type;
        internal uint reserved;
        internal ulong timestamp;
        internal uint joystickID;
        internal byte hat;
        internal byte value;
        private byte padding1;
        private byte padding2;
    }
}