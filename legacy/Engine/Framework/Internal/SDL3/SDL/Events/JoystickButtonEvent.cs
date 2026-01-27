using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct JoystickButtonEvent
    {
        public SDL.EventType type;
        public uint reserved;
        public ulong timestamp;
        public uint joystickID;
        public byte button;
        public SDL.Bool down;
        private byte padding1;
        private byte padding2;
    }
}