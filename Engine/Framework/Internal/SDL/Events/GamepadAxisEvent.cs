using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GamepadAxisEvent
    {
        public SDL.EventType type;
        public uint reserved;
        public ulong timestamp;
        public uint which;
        public byte axis;
        public byte padding1;
        public byte padding2;
        public byte padding3;
        public short value;
        public ushort padding4;
    }
}