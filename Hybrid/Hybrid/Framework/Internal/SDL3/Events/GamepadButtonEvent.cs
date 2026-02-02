using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct GamepadButtonEvent
    {
        internal SDL.EventType type;
        internal uint reserved;
        internal ulong timestamp;
        internal uint gamepadID;
        internal SDL.GamepadButton button;
        internal SDL.Bool down;
        private byte padding1;
        private byte padding2;
    }
}