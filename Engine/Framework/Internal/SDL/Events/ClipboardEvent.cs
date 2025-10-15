using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ClipboardEvent
    {
        public SDL.EventType type;
        public uint reserved;
        public ulong timestamp;
        public SDL.Bool owner;
        public int num_mime_types;
        public byte** mime_types;
    }
}