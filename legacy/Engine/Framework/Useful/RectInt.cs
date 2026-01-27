using System;

namespace Hybrid
{
    // Rect Int
    public partial struct RectInt
    {
        public static readonly RectInt Zero = new RectInt(0, 0, 0, 0);
        public static readonly RectInt One = new RectInt(0, 0, 1, 1);
        
        public int X;
        public int Y;
        public int W;
        public int H;
        

        public RectInt(int x, int y, int w, int h)
        {
            this.X = x;
            this.Y = y;
            this.W = w;
            this.H = h;
        }

        public RectInt()
        {
            
        }
    }

    // SDL
    public partial struct RectInt
    {
        public static explicit operator RectInt(Rect rect)
        {
            return new RectInt
            {
                X = Maths.RoundToInt(rect.X),
                Y = Maths.RoundToInt(rect.Y),
                W = Maths.RoundToInt(rect.W),
                H = Maths.RoundToInt(rect.H),
            };
        }
        
        internal static RectInt FromSDL(SDL.RectInt? rect)
        {
            if (!rect.HasValue) return new RectInt();

            return new RectInt
            {
                X = rect.Value.x,
                Y = rect.Value.y,
                W = rect.Value.w,
                H = rect.Value.h,
            };
        }

        internal static SDL.RectInt? ToSDL(RectInt? rect)
        {
            if (!rect.HasValue) return new SDL.RectInt();

            return new SDL.RectInt
            {
                x = rect.Value.X,
                y = rect.Value.Y,
                w = rect.Value.W,
                h = rect.Value.H,
            };
        }
    }
}