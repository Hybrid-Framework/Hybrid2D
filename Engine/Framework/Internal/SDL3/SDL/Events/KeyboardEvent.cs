using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct KeyboardEvent
    {
        public SDL.EventType type;
        public uint reserved;
        public ulong timestamp;
        public uint windowID;
        public uint keyboardID;
        private int scanCode;
        public SDL.KeyCode keyCode;
        public SDL.KeyModifier keyModifier;
        private ushort raw;
        private SDL.Bool down;
        private SDL.Bool repeat;
    }
}