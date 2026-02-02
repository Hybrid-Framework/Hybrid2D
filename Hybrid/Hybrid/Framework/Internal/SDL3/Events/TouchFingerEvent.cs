using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct TouchFingerEvent
    {
        internal SDL.EventType type;
        internal uint reserved;
        internal ulong timestamp;
        internal ulong touchDeviceID;
        internal ulong fingerID;
        internal float x;
        internal float y;
        internal float x_delta;
        internal float y_delta;
        internal float pressure;
        internal uint windowID;
    }
}