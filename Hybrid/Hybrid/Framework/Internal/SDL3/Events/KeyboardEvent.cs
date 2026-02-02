using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct KeyboardEvent
    {
        internal SDL.EventType type;
        internal uint reserved;
        internal ulong timestamp;
        internal uint windowID;
        internal uint keyboardID;
        internal SDL.ScanCode scanCode;
        internal SDL.KeyCode keyCode;
        internal SDL.KeyModifier keyModifier;
        internal ushort raw;
        internal SDL.Bool down;
        internal SDL.Bool repeat;
    }
}