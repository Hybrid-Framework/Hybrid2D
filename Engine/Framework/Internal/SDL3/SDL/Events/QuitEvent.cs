using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct QuitEvent
    {
        public SDL.EventType type;
        public uint reserved;
        public ulong timestamp;
    }
}