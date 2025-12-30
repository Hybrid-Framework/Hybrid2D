using System;

namespace Hybrid
{
    // Rect
    public partial struct Rect
    {
        public static readonly Rect Zero = new Rect(0, 0, 0, 0);
        public static readonly Rect One = new Rect(0, 0, 1, 1);
        
        public float X;
        public float Y;
        public float W;
        public float H;
        

        public Rect(float x, float y, float w, float h)
        {
            this.X = x;
            this.Y = y;
            this.W = w;
            this.H = h;
        }

        public Rect()
        {
            
        }
    }

    // SDL
    public partial struct Rect
    {
        public static explicit operator Rect(RectInt rect)
        {
            return new Rect
            {
                X = rect.X,
                Y = rect.Y,
                W = rect.W,
                H = rect.H,
            };
        }
        
        internal static Rect? FromSDL(SDL.Rect? rect)
        {
            if (!rect.HasValue) return new Rect();

            return new Rect
            {
                X = rect.Value.x,
                Y = rect.Value.y,
                W = rect.Value.w,
                H = rect.Value.h,
            };
        }

        internal static SDL.Rect? ToSDL(Rect? rect)
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