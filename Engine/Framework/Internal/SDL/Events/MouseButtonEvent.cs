using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MouseButtonEvent
    {
        public SDL.EventType type;
        public uint reserved;
        public ulong timestamp;
        public uint windowID;
        public uint mouseID;
        public byte button;
        public SDL.Bool down;
        private byte clicks;
        private byte padding;
        public float x;
        public float y;
    }
}