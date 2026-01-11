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
        public float r;
        
        public Circle(float x, float y, float r)
        {
            this.x = x;
            this.y = y;
            this.r = r;
        }

        public Circle()
        {
            
        }
    }
}