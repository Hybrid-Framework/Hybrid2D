using System;

namespace Hybrid
{
    // Color
    public partial struct Color32
    {
        public static readonly Color32 Cornflower = new Color32(100, 149, 237, 255);
        public static readonly Color32 Transparent = new Color32(0, 0, 0, 255);
        public static readonly Color32 White = new Color32(255, 255, 255, 255);
        public static readonly Color32 Black = new Color32(0, 0, 0, 255);
        public static readonly Color32 Blue = new Color32(0, 0, 255, 255);
        public static readonly Color32 Green = new Color32(0, 255, 0, 255);
        public static readonly Color32 Red = new Color32(255, 0, 0, 255);
        public static readonly Color32 Brown = new Color32(165, 42, 42, 255);
        public static readonly Color32 Purple = new Color32(128, 0, 128, 255);
        public static readonly Color32 Gold = new Color32(255, 215, 0, 255);
        public static readonly Color32 Orange = new Color32(255, 165, 0, 255);
        public static readonly Color32 Cyan = new Color32(0, 255, 255, 255);
        public static readonly Color32 Magenta = new Color32(255, 0, 255, 255);
        public static readonly Color32 Gray = new Color32(128, 128, 128, 255);
        public static readonly Color32 Pink = new Color32(255, 192, 203, 255);
        public static readonly Color32 Olive = new Color32(128, 128, 0, 255);
        public static readonly Color32 Teal = new Color32(0, 128, 128, 255);
        public static readonly Color32 Maroon = new Color32(128, 0, 0, 255);
        public static readonly Color32 Lime = new Color32(0, 255, 0, 255);
        public static readonly Color32 Silver = new Color32(192, 192, 192, 255);
        public static readonly Color32 Coral = new Color32(255, 127, 80, 255);
        public static readonly Color32 Indigo = new Color32(75, 0, 130, 255);
        public static readonly Color32 Violet = new Color32(238, 130, 238, 255);
        public static readonly Color32 Salmon = new Color32(250, 128, 114, 255);

        private byte _R { get; set; }
        public byte R
        {
            get => _R;
            set
            {
                value = (byte)Maths.Clamp(value, 0, 255);
                _R = value;
            }
        }
        
        private byte _G { get; set; }
        public byte G
        {
            get => _G;
            set
            {
                value = (byte)Maths.Clamp(value, 0, 255);
                _G = value;
            }
        }
        
        private byte _B { get; set; }
        public byte B
        {
            get => _B;
            set
            {
                value = (byte)Maths.Clamp(value, 0, 255);
                _B = value;
            }
        }
        
        private byte _A { get; set; }
        public byte A
        {
            get => _A;
            set
            {
                value = (byte)Maths.Clamp(value, 0, 255);
                _A = value;
            }
        }

        public Color32(byte r, byte g, byte b, byte a)
        {
            this.R = r;
            this.G = g;
            this.B = b;
            this.A = a;
        }

        public Color32()
        {
            
        }
    }
    
    // Operators
    public partial struct Color32
    {
        public static explicit operator Color32(Color c)
        {
            return new Color32
            (
                (byte)(Maths.Clamp(c.R, 0f, 1f) * 255f),
                (byte)(Maths.Clamp(c.G, 0f, 1f) * 255f),
                (byte)(Maths.Clamp(c.B, 0f, 1f) * 255f),
                (byte)(Maths.Clamp(c.A, 0f, 1f) * 255f)
            );
        }
        
        internal static Color32 FromSDL(SDL.Color32 color)
        {
            return new Color32
            {
                R = color.r,
                G = color.g,
                B = color.b,
                A = color.a,
            };
        }
        
        internal static SDL.Color32 ToSDL(Color32 color32)
        {
            return new SDL.Color32
            {
                r = color32.R,
                g = color32.G,
                b = color32.B,
                a = color32.A,
            };
        }
    }
}