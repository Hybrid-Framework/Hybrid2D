using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    // Point
    [StructLayout(LayoutKind.Sequential)]
    internal struct PointInt
    {
        internal int x;
        internal int y;

        internal PointInt(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}