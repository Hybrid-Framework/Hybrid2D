using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AudioDeviceEvent
    {
        public SDL.EventType type;
        public uint reserved;
        public ulong timestamp;
        public uint audioDeviceID;
        public SDL.Bool recording;
        private byte padding1;
        private byte padding2;
        private byte padding3;
    }
}