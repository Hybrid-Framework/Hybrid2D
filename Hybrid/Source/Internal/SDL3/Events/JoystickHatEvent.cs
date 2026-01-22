using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct JoystickHatEvent
    {
        public SDL.EventType type;
        public uint reserved;
        public ulong timestamp;
        public uint joystickID;
        public byte hat;
        public byte value;
        private byte padding1;
        private byte padding2;
    }
}