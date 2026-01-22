using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    // Color 32
    [StructLayout(LayoutKind.Sequential)]
    internal struct Color32
    {
        internal byte r;
        internal byte g;
        internal byte b;
        internal byte a;

        internal Color32(byte r, byte g, byte b, byte a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }
    }
}