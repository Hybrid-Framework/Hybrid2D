using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayEvent
    {
        public SDL.EventType type;
        public uint reserved;
        public ulong timestamp;
        public uint displayID;
        private int data1;
        private int data2;
    }
}