using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    // Rect
    [StructLayout(LayoutKind.Sequential)]
    public partial struct Rectangle
    {
        public float x;
        public float y;
        public float width;
        public float height;
        
        public Rectangle(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
    }
    
    // SDL
    public partial struct Rectangle
    {
        internal static SDL.Rect? ToSDLRect(Rectangle? rect)
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

        internal static SDL.RectInt? ToSDLRectInt(Rectangle? rect)
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

        internal static Rectangle? FromSDLRect(SDL.Rect? rect)
        {
            if (rect.HasValue)
            {
                return new Rectangle
                (
                    rect.Value.x,
                    rect.Value.x,
                    rect.Value.x,
                    rect.Value.x
                );
            }

            return new Rectangle();
        }
        
        internal static Rectangle? FromSDLRectInt(SDL.RectInt? rect)
        {
            if (rect.HasValue)
            {
                return new Rectangle
                (
                    rect.Value.x,
                    rect.Value.x,
                    rect.Value.x,
                    rect.Value.x
                );
            }

            return new Rectangle();
        }
    }
}