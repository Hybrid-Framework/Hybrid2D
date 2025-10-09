using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MouseWheelEvent
    {
        public SDL.EventType type;
        public uint reserved;
        public ulong timestamp;
        public uint windowID;
        public uint which;
        public float x;
        public float y;
        public SDL.MouseWheelDirection direction;
        public float mouse_x;
        public float mouse_y;
        public int integer_x;
        public int integer_y;
    }
}