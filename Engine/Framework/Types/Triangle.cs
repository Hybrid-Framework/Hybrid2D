using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    // Triangle
    [StructLayout(LayoutKind.Sequential)]
    public struct Triangle
    {
        public Point point1;
        public Point point2;
        public Point point3;

        public Triangle(Point point1, Point point2, Point point3)
        {
            this.point1 = point1;
            this.point2 = point2;
            this.point3 = point3;
        }
    }
}