using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    // Circle
    [StructLayout(LayoutKind.Sequential)]
    public struct Circle
    {
        public float x;
        public float y;
        public float radius;
        
        public Circle(float x, float y, float radius)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }
    }
}