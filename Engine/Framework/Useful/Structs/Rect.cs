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
    }
    
    // Properties
    public partial struct Rect
    {
        public static readonly Rect Zero = new(0, 0, 0, 0);
        public static readonly Rect One = new(1, 1, 1, 1);
    }
    
    // Methods
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
                    x = (int)rect.Value.X,
                    y = (int)rect.Value.Y,
                    w = (int)rect.Value.W,
                    h = (int)rect.Value.H
                };
            }

            return null;
        }
    }
}