using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    // Point
    [StructLayout(LayoutKind.Sequential)]
    public partial struct Point
    {
        // X Value
        public float x;
        
        // Y Value
        public float y;

        // Constructor
        public Point(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        // Constructor
        public Point()
        {
            
        }
    }
    
    // SDL
    public partial struct Point
    {
        internal static SDL.Point ToSDLPoint(Point point)
        {
            return new SDL.Point
            (
                point.x,
                point.y
            );
        }

        internal static SDL.PointInt ToSDLPointInt(Point point)
        {
            return new SDL.PointInt
            (
                (int)point.x,
                (int)point.y
            );
        }

        internal static Point FromSDLPoint(SDL.Point point)
        {
            return new Point
            (
                point.x,
                point.y
            );
        }
        
        internal static Point FromSDLPointInt(SDL.PointInt point)
        {
            return new Point
            (
                point.x,
                point.y
            );
        }
    }
}