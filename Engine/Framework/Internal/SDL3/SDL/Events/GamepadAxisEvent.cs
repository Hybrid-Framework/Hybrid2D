using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GamepadAxisEvent
    {
        public SDL.EventType type;
        public uint reserved;
        public ulong timestamp;
        public uint gamepadID;
        public SDL.GamepadAxis axis;
        private byte padding1;
        private byte padding2;
        private byte padding3;
        public short value;
        private ushort padding4;
    }
}