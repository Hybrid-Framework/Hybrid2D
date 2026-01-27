using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    // Point
    [StructLayout(LayoutKind.Sequential)]
    public partial struct Point
    {
        // Point Zero
        public static readonly Point Zero = new Point(0, 0);
        
        // Point One
        public static readonly Point One = new Point(1, 1);
        
        // Point Left
        public static readonly Point Left = new Point(-1, 0);
        
        // Point Right
        public static readonly Point Right = new Point(1, 0);
        
        // Point Down
        public static readonly Point Down = new Point(0, -1);
        
        // Point Up
        public static readonly Point Up = new Point(0, 1);
        
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