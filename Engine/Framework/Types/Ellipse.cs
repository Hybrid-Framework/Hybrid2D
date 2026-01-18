using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    // Ellipse
    [StructLayout(LayoutKind.Sequential)]
    public struct Ellipse
    {
        public float x;
        public float y;
        public float radiusX;
        public float radiusY;

        public Ellipse(float x, float y, float rx, float ry)
        {
            this.x = x;
            this.y = y;
            radiusX = rx;
            radiusY = ry;
        }
    }
}