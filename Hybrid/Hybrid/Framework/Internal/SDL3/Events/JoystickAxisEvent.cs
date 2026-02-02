using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct JoystickAxisEvent
    {
        internal SDL.EventType type;
        internal uint reserved;
        internal ulong timestamp;
        internal uint joystickID;
        internal byte axis;
        private byte padding1;
        private byte padding2;
        private byte padding3;
        internal short value;
        private ushort padding4;
    }
}