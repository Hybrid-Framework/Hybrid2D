using System;

namespace Hybrid
{
    public partial struct Rect
    {
        public float x;
        public float y;
        public float w;
        public float h;

        public Rect(float x, float y, float w, float h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }
    }
    
    public partial struct Rect
    {
        internal static SDL.FRect? SDLFRect(Rect? rect)
        {
            if (rect.HasValue)
            {
                return new SDL.FRect()
                {
                    x = rect.Value.x,
                    y = rect.Value.y,
                    w = rect.Value.w,
                    h = rect.Value.h
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
                    x = (int)rect.Value.x,
                    y = (int)rect.Value.y,
                    w = (int)rect.Value.w,
                    h = (int)rect.Value.h
                };
            }

            return null;
        }
    }
}