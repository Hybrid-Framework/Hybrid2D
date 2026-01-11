using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    // Point
    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        public static readonly Point Zero  = new Point(0, 0);
        public static readonly Point One  = new Point(1, 1);
        
        public static readonly Point Left  = new Point(-1, 0);
        public static readonly Point Right  = new Point(1, 0);
        public static readonly Point Down  = new Point(0, -1);
        public static readonly Point Up  = new Point(0, 1);
        
        public float x;
        public float y;

        public Point(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Point()
        {
            
        }
    }
}