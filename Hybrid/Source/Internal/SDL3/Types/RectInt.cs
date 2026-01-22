using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    // Rect Int
    [StructLayout(LayoutKind.Sequential)]
    internal struct RectInt
    {
        internal int x;
        internal int y;
        internal int w;
        internal int h;

        internal RectInt(int x, int y, int w, int h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }
    }
}