using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct JoystickDeviceEvent
    {
        public SDL.EventType type;
        public uint reserved;
        public ulong timestamp;
        public uint joystickID;
    }
}