using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GamepadDeviceEvent
    {
        public SDL.EventType type;
        public uint reserved;
        public ulong timestamp;
        public uint gamepadID;
    }
}