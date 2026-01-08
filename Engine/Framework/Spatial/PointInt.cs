using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    // Point Int
    [StructLayout(LayoutKind.Sequential)]
    public struct PointInt
    {
        public int X;
        public int Y;


        public PointInt(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}