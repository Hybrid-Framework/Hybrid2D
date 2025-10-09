using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayEvent
    {
        public SDL.EventType type;
        public uint reserved;
        public ulong timestamp;
        public uint displayID;
        public int data1;
        public int data2;
    }
}