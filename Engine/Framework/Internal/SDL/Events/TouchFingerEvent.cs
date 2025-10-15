using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TouchFingerEvent
    {
        public SDL.EventType type;
        public uint reserved;
        public ulong timestamp;
        public ulong touchID;
        public ulong fingerID;
        public float x;
        public float y;
        public float dx;
        public float dy;
        public float pressure;
        public uint windowID;
    }
}