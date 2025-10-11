using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    public struct Pixel
    {
        public int x;
        public int y;
        public byte r;
        public byte g;
        public byte b;
        public byte a;
    }
}