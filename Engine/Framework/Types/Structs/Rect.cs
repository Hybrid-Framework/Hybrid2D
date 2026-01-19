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
        public float width;
        public float height;
        
        public Rect(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
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
                    rect.Value.width,
                    rect.Value.height
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
                    Maths.RoundToInt(rect.Value.width),
                    Maths.RoundToInt(rect.Value.height)
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