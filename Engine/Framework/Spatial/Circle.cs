using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    // Circle
    [StructLayout(LayoutKind.Sequential)]
    public struct Circle
    {
        public float X;
        public float Y;
        public float R;
        
        public Circle(float x, float y, float r)
        {
            this.X = x;
            this.Y = y;
            this.R = r;
        }
    }
}