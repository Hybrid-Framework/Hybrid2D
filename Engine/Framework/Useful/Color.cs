using System;

namespace Hybrid
{
    public partial struct Color
    {
        public byte r;
        public byte g;
        public byte b;
        public byte a;

        public Color(byte r, byte g, byte b, byte a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }
    }

    public partial struct Color
    {
        public static readonly Color Transparent = new(0, 0, 0, 0);
        public static readonly Color Black = new(0, 0, 0, 255);
        public static readonly Color White = new(255, 255, 255, 255);
        public static readonly Color Red = new(255, 0, 0, 255);
        public static readonly Color Green = new(0, 255, 0, 255);
        public static readonly Color Blue = new(0, 0, 255, 255);
        public static readonly Color Yellow = new(255, 255, 0, 255);
        public static readonly Color Cyan = new(0, 255, 255, 255);
        public static readonly Color Magenta = new(255, 0, 255, 255);
        public static readonly Color Gray = new(128, 128, 128, 255);
        public static readonly Color Orange = new(255, 165, 0, 255);
        public static readonly Color Brown = new(165, 42, 42, 255);
        public static readonly Color Purple = new(128, 0, 128, 255);
        public static readonly Color Pink = new(255, 192, 203, 255);
        public static readonly Color Lime = new(0, 255, 0, 255);
        public static readonly Color Navy = new(0, 0, 128, 255);
        public static readonly Color Teal = new(0, 128, 128, 255);
        public static readonly Color Olive = new(128, 128, 0, 255);
        public static readonly Color Maroon = new(128, 0, 0, 255);
        public static readonly Color Silver = new(192, 192, 192, 255);
        public static readonly Color Gold = new(255, 215, 0, 255);
        public static readonly Color Coral = new(255, 127, 80, 255);
        public static readonly Color Salmon = new(250, 128, 114, 255);
        public static readonly Color Violet = new(238, 130, 238, 255);
        public static readonly Color Indigo = new(75, 0, 130, 255);
        public static readonly Color Turquoise = new(64, 224, 208, 255);
    }
}