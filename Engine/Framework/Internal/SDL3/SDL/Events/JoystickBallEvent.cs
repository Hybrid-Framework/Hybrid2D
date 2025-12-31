using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct JoystickBallEvent
    {
        public SDL.EventType type;
        public uint reserved;
        public ulong timestamp;
        public uint joystickID;
        public byte ball;
        private byte padding1;
        private byte padding2;
        private byte padding3;
        public short x_relative;
        public short y_relative;
    }
}