using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    // Rect
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        public float x;
        public float y;
        public float w;
        public float h;
        
        public Rect(float x, float y, float w, float h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }

        public Rect()
        {
            
        }
    }
}