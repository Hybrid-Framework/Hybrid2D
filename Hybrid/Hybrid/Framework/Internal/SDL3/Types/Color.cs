using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    // Color
    [StructLayout(LayoutKind.Sequential)]
    internal struct Color
    {
        internal float r;
        internal float g;
        internal float b;
        internal float a;

        internal Color(float r, float g, float b, float a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }
    }
}