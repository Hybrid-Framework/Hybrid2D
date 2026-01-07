using System;

namespace Hybrid
{
    // Point
    public partial struct Point
    {
        public float X;
        public float Y;
        

        public Point(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public Point()
        {
            
        }
    }

    // SDL
    public partial struct Point
    {
        public static explicit operator Point(PointInt point)
        {
            return new Point
            {
                X = point.X,
                Y = point.Y,
            };
        }
        
        internal static Point FromSDL(SDL.Point? point)
        {
            if (!point.HasValue) return new Point();

            return new Point
            {
                X = point.Value.x,
                Y = point.Value.y,
            };
        }

        internal static SDL.Point? ToSDL(Point? point)
        {
            if (!point.HasValue) return new SDL.Point();

            return new SDL.Point
            {
                x = point.Value.X,
                y = point.Value.Y,
            };
        }
    }
}