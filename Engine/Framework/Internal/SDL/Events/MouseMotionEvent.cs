using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MouseMotionEvent
    {
        public SDL.EventType type;
        public uint reserved;
        public ulong timestamp;
        public uint windowID;
        public uint which;
        public SDL.MouseButtonFlags state;
        public float x;
        public float y;
        public float relative_x;
        public float relative_y;
    }
}