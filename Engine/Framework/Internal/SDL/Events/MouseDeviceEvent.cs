using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MouseDeviceEvent
    {
        public SDL.EventType type;
        public uint reserved;
        public ulong timestamp;
        public uint mouseID;
    }
}