using System;

namespace Hybrid
{
    // Color
    public partial struct Color
    {
        public static readonly Color Cornflower = new Color32(100, 149, 237, 255);
        public static readonly Color Transparent = new Color32(0, 0, 0, 255);
        public static readonly Color White = new Color32(255, 255, 255, 255);
        public static readonly Color Black = new Color32(0, 0, 0, 255);
        public static readonly Color Blue = new Color32(0, 0, 255, 255);
        public static readonly Color Green = new Color32(0, 255, 0, 255);
        public static readonly Color Red = new Color32(255, 0, 0, 255);
        public static readonly Color Brown = new Color32(165, 42, 42, 255);
        public static readonly Color Purple = new Color32(128, 0, 128, 255);
        public static readonly Color Gold = new Color32(255, 215, 0, 255);
        public static readonly Color Orange = new Color32(255, 165, 0, 255);
        public static readonly Color Cyan = new Color32(0, 255, 255, 255);
        public static readonly Color Magenta = new Color32(255, 0, 255, 255);
        public static readonly Color Gray = new Color32(128, 128, 128, 255);
        public static readonly Color Pink = new Color32(255, 192, 203, 255);
        public static readonly Color Olive = new Color32(128, 128, 0, 255);
        public static readonly Color Teal = new Color32(0, 128, 128, 255);
        public static readonly Color Maroon = new Color32(128, 0, 0, 255);
        public static readonly Color Lime = new Color32(0, 255, 0, 255);
        public static readonly Color Silver = new Color32(192, 192, 192, 255);
        public static readonly Color Coral = new Color32(255, 127, 80, 255);
        public static readonly Color Indigo = new Color32(75, 0, 130, 255);
        public static readonly Color Violet = new Color32(238, 130, 238, 255);
        public static readonly Color Salmon = new Color32(250, 128, 114, 255);
        
        private float _R { get; set; }
        public float R
        {
            get => _R;
            set
            {
                value = Maths.Clamp(value, 0, 1);
                _R = value;
            }
        }
        
        private float _G { get; set; }
        public float G
        {
            get => _G;
            set
            {
                value = Maths.Clamp(value, 0, 1);
                _G = value;
            }
        }
        
        private float _B { get; set; }
        public float B
        {
            get => _B;
            set
            {
                value = Maths.Clamp(value, 0, 1);
                _B = value;
            }
        }
        
        private float _A { get; set; }
        public float A
        {
            get => _A;
            set
            {
                value = Maths.Clamp(value, 0, 1);
                _A = value;
            }
        }

        public Color(float r, float g, float b, float a)
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
    
    // Operators
    public partial struct Color
    {
        public static implicit operator Color(Color32 c)
        {
            return new Color
            (
                c.R / 255f,
                c.G / 255f,
                c.B / 255f,
                c.A / 255f
            );
        }
        
        internal static Color FromSDL(SDL.Color color)
        {
            return new Color
            {
                R = color.r,
                G = color.g,
                B = color.b,
                A = color.a,
            };
        }
        
        internal static SDL.Color ToSDL(Color color)
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