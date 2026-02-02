using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct AudioDeviceEvent
    {
        internal SDL.EventType type;
        internal uint reserved;
        internal ulong timestamp;
        internal uint audioDeviceID;
        internal SDL.Bool recording;
        private byte padding1;
        private byte padding2;
        private byte padding3;
    }
}