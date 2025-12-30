using System;

namespace Hybrid
{
    // Point Int
    public partial struct PointInt
    {
        public int X;
        public int Y;
        

        public PointInt(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public PointInt()
        {
            
        }
    }

    // SDL
    public partial struct PointInt
    {
        public static explicit operator PointInt(Point point)
        {
            return new PointInt
            {
                X = Maths.RoundToInt(point.X),
                Y = Maths.RoundToInt(point.Y),
            };
        }
        
        internal static PointInt FromSDL(SDL.PointInt? point)
        {
            if (!point.HasValue) return new PointInt();

            return new PointInt
            {
                X = point.Value.x,
                Y = point.Value.y,
            };
        }

        internal static SDL.PointInt? ToSDL(PointInt? point)
        {
            if (!point.HasValue) return new SDL.PointInt();

            return new SDL.PointInt
            {
                x = point.Value.X,
                y = point.Value.Y,
            };
        }
    }
}