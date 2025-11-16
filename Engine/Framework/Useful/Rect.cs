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
            if (rect.HasValue)
            {
                return new SDL.FRect()
                {
                    x = rect.Value.X,
                    y = rect.Value.Y,
                    w = rect.Value.W,
                    h = rect.Value.H
                };
            }

            return null;
        }
        
        internal static SDL.Rect? SDLRect(Rect? rect)
        {
            if (rect.HasValue)
            {
                return new SDL.Rect()
                {
                    x = (int)Maths.Round(rect.Value.X),
                    y = (int)Maths.Round(rect.Value.Y),
                    w = (int)Maths.Round(rect.Value.W),
                    h = (int)Maths.Round(rect.Value.H)
                };
            }

            return null;
        }
    }
}