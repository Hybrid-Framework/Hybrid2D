using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GamepadButtonEvent
    {
        public SDL.EventType type;
        public uint reserved;
        public ulong timestamp;
        public uint which;
        public byte button;
        public SDL.Bool down;
        private byte padding1;
        private byte padding2;
    }
}