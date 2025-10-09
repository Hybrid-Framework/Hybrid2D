using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AudioDeviceEvent
    {
        public SDL.EventType type;
        public uint reserved;
        public ulong timestamp;
        public uint which;
        public SDL.Bool recording;
        public byte padding1;
        public byte padding2;
        public byte padding3;
    }
}