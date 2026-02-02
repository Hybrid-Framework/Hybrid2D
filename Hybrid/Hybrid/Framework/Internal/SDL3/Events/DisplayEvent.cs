using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct DisplayEvent
    {
        internal SDL.EventType type;
        internal uint reserved;
        internal ulong timestamp;
        internal uint displayID;
        private int data1;
        private int data2;
    }
}