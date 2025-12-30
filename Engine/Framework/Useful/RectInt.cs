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
        internal RectInt(SDL.Rect? rect)
        {
            if (!rect.HasValue) return;

            this.X = Maths.RoundToInt(rect.Value.x);
            this.Y = Maths.RoundToInt(rect.Value.y);
            this.W = Maths.RoundToInt(rect.Value.w);
            this.H = Maths.RoundToInt(rect.Value.h);
        }
        
        internal RectInt(SDL.RectInt? rect)
        {
            if (!rect.HasValue) return;

            this.X = rect.Value.x;
            this.Y = rect.Value.y;
            this.W = rect.Value.w;
            this.H = rect.Value.h;
        }
        
        internal static SDL.Rect? SDLRect(RectInt? rect)
        {
            if (!rect.HasValue) return new SDL.Rect();

            return new SDL.Rect
            {
                x = rect.Value.X,
                y = rect.Value.Y,
                w = rect.Value.W,
                h = rect.Value.H,
            };
        }
        
        internal static SDL.RectInt? SDLRectInt(RectInt? rect)
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