using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        public int x;
        public int y;
        public int w;
        public int h;
    }
}