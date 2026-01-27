using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    // Rect
    [StructLayout(LayoutKind.Sequential)]
    internal struct Rect
    {
        internal float x;
        internal float y;
        internal float w;
        internal float h;
        
        internal Rect(float x, float y, float w, float h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }
    }
}