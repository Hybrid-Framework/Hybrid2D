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
        internal static SDL.FRect? SDLFRect(RectInt? rect)
        {
            if (!rect.HasValue) return new SDL.FRect();

            return new SDL.FRect
            {
                x = rect.Value.X,
                y = rect.Value.Y,
                w = (float)rect.Value.W,
                h = (float)rect.Value.H,
            };
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
    }
}