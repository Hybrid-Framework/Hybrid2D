using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    // Point
    [StructLayout(LayoutKind.Sequential)]
    internal struct Point
    {
        internal float x;
        internal float y;

        internal Point(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
}