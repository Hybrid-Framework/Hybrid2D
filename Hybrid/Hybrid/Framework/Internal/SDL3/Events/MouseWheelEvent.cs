using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct MouseWheelEvent
    {
        internal SDL.EventType type;
        internal uint reserved;
        internal ulong timestamp;
        internal uint windowID;
        internal uint mouseID;
        internal float x;
        internal float y;
        internal SDL.MouseWheelDirection direction;
        internal float x_mouse;
        internal float y_mouse;
        internal int x_integer;
        internal int y_integer;
    }
}