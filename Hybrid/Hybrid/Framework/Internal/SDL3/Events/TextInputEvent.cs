using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct TextInputEvent
    {
        internal SDL.EventType type;
        internal uint reserved;
        internal ulong timestamp;
        internal uint windowID;
        internal byte* text;
    }
}