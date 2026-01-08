using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    // Rect Int
    [StructLayout(LayoutKind.Sequential)]
    public struct RectInt
    {
        public int X;
        public int Y;
        public int W;
        public int H;


        public RectInt(int x, int y, int w, int h)
        {
            this.X = x;
            this.Y = y;
            this.W = w;
            this.H = h;
        }
    }
}