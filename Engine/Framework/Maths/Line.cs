using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    // Line
    [StructLayout(LayoutKind.Sequential)]
    public struct Line
    {
        public float thickness;
        public Point start;
        public Point end;

        public Line(Point start, Point end, float thickness)
        {
            this.thickness = thickness;
            this.start = start;
            this.end = end;
        }
    }
}