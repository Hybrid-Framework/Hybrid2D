using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    // Point
    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        public float X;
        public float Y;


        public Point(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}