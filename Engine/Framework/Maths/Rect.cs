using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    // Rect
    [StructLayout(LayoutKind.Sequential)]
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

        public Rect()
        {
            
        }
    }
    
    // SDL
    public partial struct Rect
    {
        internal static SDL.Rect? ToSDLRect(Rect? rect)
        {
            if (rect.HasValue)
            {
                return new SDL.Rect
                (
                    rect.Value.x,
                    rect.Value.y,
                    rect.Value.w,
                    rect.Value.h
                );
            }

            return null;
        }

        internal static SDL.RectInt? ToSDLRectInt(Rect? rect)
        {
            if (rect.HasValue)
            {
                return new SDL.RectInt
                (
                    Maths.RoundToInt(rect.Value.x),
                    Maths.RoundToInt(rect.Value.y),
                    Maths.RoundToInt(rect.Value.w),
                    Maths.RoundToInt(rect.Value.h)
                );
            }

            return null;
        }

        internal static Rect? FromSDLRect(SDL.Rect? rect)
        {
            if (rect.HasValue)
            {
                return new Rect
                (
                    rect.Value.x,
                    rect.Value.x,
                    rect.Value.x,
                    rect.Value.x
                );
            }

            return new Rect();
        }
        
        internal static Rect? FromSDLRectInt(SDL.RectInt? rect)
        {
            if (rect.HasValue)
            {
                return new Rect
                (
                    rect.Value.x,
                    rect.Value.x,
                    rect.Value.x,
                    rect.Value.x
                );
            }

            return new Rect();
        }
    }
}