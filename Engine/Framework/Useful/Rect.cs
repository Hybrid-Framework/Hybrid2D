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
        internal static SDL.FRect? SDLFRect(Rect? rect)
        {
            if (!rect.HasValue) return new SDL.FRect();

            return new SDL.FRect
            {
                x = rect.Value.X,
                y = rect.Value.Y,
                w = rect.Value.W,
                h = rect.Value.H,
            };
        }
        
        internal static SDL.Rect? SDLRect(Rect? rect)
        {
            if (!rect.HasValue) return new SDL.Rect();

            return new SDL.Rect
            {
                x = Maths.RoundToInt(rect.Value.X),
                y = Maths.RoundToInt(rect.Value.Y),
                w = Maths.RoundToInt(rect.Value.W),
                h = Maths.RoundToInt(rect.Value.H),
            };
        }
    }
}