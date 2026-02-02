using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct MouseButtonEvent
    {
        internal SDL.EventType type;
        internal uint reserved;
        internal ulong timestamp;
        internal uint windowID;
        internal uint mouseID;
        internal byte button;
        internal SDL.Bool down;
        private byte clicks;
        private byte padding;
        internal float x;
        internal float y;
    }
}