using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RectInt
    {
        public int x;
        public int y;
        public int w;
        public int h;
    }
}