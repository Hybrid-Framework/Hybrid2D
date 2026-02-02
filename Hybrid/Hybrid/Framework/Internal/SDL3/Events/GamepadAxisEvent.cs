using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct GamepadAxisEvent
    {
        internal SDL.EventType type;
        internal uint reserved;
        internal ulong timestamp;
        internal uint gamepadID;
        internal SDL.GamepadAxis axis;
        private byte padding1;
        private byte padding2;
        private byte padding3;
        internal short value;
        private ushort padding4;
    }
}