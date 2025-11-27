using System;

namespace Hybrid
{
    // Color
    public partial struct Color
    {
        public static readonly Color Cornflower = new Color(100, 149, 237, 255);
        public static readonly Color Transparent = new Color(0, 0, 0, 255);
        public static readonly Color White = new Color(255, 255, 255, 255);
        public static readonly Color Black = new Color(0, 0, 0, 255);
        public static readonly Color Blue = new Color(0, 0, 255, 255);
        public static readonly Color Green = new Color(0, 255, 0, 255);
        public static readonly Color Red = new Color(255, 0, 0, 255);
        public static readonly Color Brown = new Color(165, 42, 42, 255);
        public static readonly Color Purple = new Color(128, 0, 128, 255);
        public static readonly Color Gold = new Color(255, 215, 0, 255);
        public static readonly Color Orange = new Color(255, 165, 0, 255);
        public static readonly Color Cyan = new Color(0, 255, 255, 255);
        public static readonly Color Magenta = new Color(255, 0, 255, 255);
        public static readonly Color Gray = new Color(128, 128, 128, 255);
        public static readonly Color Pink = new Color(255, 192, 203, 255);
        public static readonly Color Olive = new Color(128, 128, 0, 255);
        public static readonly Color Teal = new Color(0, 128, 128, 255);
        public static readonly Color Maroon = new Color(128, 0, 0, 255);
        public static readonly Color Lime = new Color(0, 255, 0, 255);
        public static readonly Color Silver = new Color(192, 192, 192, 255);
        public static readonly Color Coral = new Color(255, 127, 80, 255);
        public static readonly Color Indigo = new Color(75, 0, 130, 255);
        public static readonly Color Violet = new Color(238, 130, 238, 255);
        public static readonly Color Salmon = new Color(250, 128, 114, 255);
        
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