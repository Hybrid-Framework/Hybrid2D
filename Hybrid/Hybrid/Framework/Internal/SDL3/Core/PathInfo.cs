using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct PathInfo
    {
        internal SDL.PathType type;
        internal ulong size;
        internal long created;
        internal long modified;
        internal long accessed;
    }
}