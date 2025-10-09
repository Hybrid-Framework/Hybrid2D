using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct KeyboardEvent
    {
        public SDL.EventType type;
        public uint reserved;
        public ulong timestamp;
        public uint windowID;
        public uint which;
        public SDL.ScanCode scancode;
        public uint key;
        public SDL.KeyModifier modifier;
        public ushort raw;
        public SDL.Bool down;
        public SDL.Bool repeat;
    }
}