using System;

namespace Hybrid
{
    // Color
    public partial struct Color
    {
        public byte R;
        public byte G;
        public byte B;
        public byte A;

        public Color(byte r, byte g, byte b, byte a)
        {
            this.R = r;
            this.G = g;
            this.B = b;
            this.A = a;
        }

        public Color()
        {
            
        }
    }
    
    // SDL
    public partial struct Color
    {
        internal static SDL.Color SDLColor(Color color)
        {
            return new SDL.Color
            {
                r = color.R,
                g = color.G,
                b = color.B,
                a = color.A,
            };
        }
    }
}