using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    // Point Int
    [StructLayout(LayoutKind.Sequential)]
    public struct PointInt
    {
        public int x;
        public int y;

        public PointInt(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public PointInt()
        {
            
        }
    }
}