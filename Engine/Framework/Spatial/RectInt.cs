using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    // Rect Int
    [StructLayout(LayoutKind.Sequential)]
    public struct RectInt
    {
        public int x;
        public int y;
        public int w;
        public int h;

        public RectInt(int x, int y, int w, int h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }

        public RectInt()
        {
            
        }
    }
}