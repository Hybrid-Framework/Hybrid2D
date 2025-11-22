using System;

namespace Hybrid
{
    // Rect
    public partial struct Rect
    {
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
            if (!rect.HasValue) return null;

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
            if (!rect.HasValue) return null;

            return new SDL.Rect
            {
                x = (int)rect.Value.X,
                y = (int)rect.Value.Y,
                w = (int)rect.Value.W,
                h = (int)rect.Value.H,
            };
        }
    }
}