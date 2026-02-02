using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct Finger
    {
        internal ulong id;
        internal float x;
        internal float y;
        internal float pressure;
    }
}