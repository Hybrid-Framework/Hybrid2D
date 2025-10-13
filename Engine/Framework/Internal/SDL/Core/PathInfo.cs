using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PathInfo
    {
        public SDL.PathType type;
        public ulong size;
        public long created;
        public long modified;
        public long accessed;
    }
}