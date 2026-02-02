using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct MouseMotionEvent
    {
        internal SDL.EventType type;
        internal uint reserved;
        internal ulong timestamp;
        internal uint windowID;
        internal uint mouseID;
        internal SDL.MouseButtonFlags state;
        internal float x;
        internal float y;
        internal float x_relative;
        internal float y_relative;
    }
}