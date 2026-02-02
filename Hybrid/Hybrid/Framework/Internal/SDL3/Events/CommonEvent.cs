using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct CommonEvent
    {
        internal uint type;
        internal uint reserved;
        internal ulong timestamp;
    }
}