using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    // Point
    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
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