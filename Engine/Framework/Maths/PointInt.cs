using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    // Point Int
    [StructLayout(LayoutKind.Sequential)]
    public struct PointInt
    {
        public static readonly PointInt Zero  = new PointInt(0, 0);
        public static readonly PointInt One  = new PointInt(1, 1);
        
        public static readonly PointInt Left  = new PointInt(-1, 0);
        public static readonly PointInt Right  = new PointInt(1, 0);
        public static readonly PointInt Down  = new PointInt(0, -1);
        public static readonly PointInt Up  = new PointInt(0, 1);
        
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