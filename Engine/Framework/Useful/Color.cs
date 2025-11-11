using System;

namespace Hybrid
{
    // Color
    public partial struct Color : IEquatable<Color>
    {
        private static byte RoundToByte(float value) => (byte)Maths.Clamp(Maths.Round(value), 0, 255);
        
        public static readonly Color CornFlowerBlue = new(100, 149, 237, 255);
        public static readonly Color White = new(255, 255, 255, 255);
        public static readonly Color Black = new(0, 0, 0, 255);
        public static readonly Color Red = new(255, 0, 0, 255);
        public static readonly Color Green = new(0, 255, 0, 255);
        public static readonly Color Blue = new(0, 0, 255, 255);
        public static readonly Color Yellow = new(255, 255, 0, 255);
        public static readonly Color Cyan = new(0, 255, 255, 255);
        public static readonly Color Magenta = new(255, 0, 255, 255);
        public static readonly Color Gray = new(128, 128, 128, 255);
        public static readonly Color Orange = new(255, 165, 0, 255);
        public static readonly Color Pink = new(255, 192, 203, 255);
        public static readonly Color Purple = new(128, 0, 128, 255);
        public static readonly Color Brown = new(139, 69, 19, 255);
        public static readonly Color Lime = new(50, 205, 50, 255);
        public static readonly Color Salmon = new(255, 128, 128, 255);
        public static readonly Color Olive = new(128, 128, 0, 255);
        public static readonly Color Teal = new(0, 128, 128, 255);
        public static readonly Color Navy = new(0, 0, 128, 255);
        public static readonly Color Maroon = new(128, 0, 0, 255);
        public static readonly Color Gold = new(255, 215, 0, 255);
        public static readonly Color Silver = new(192, 192, 192, 255);
        public static readonly Color Coral = new(255, 127, 80, 255);
        public static readonly Color Indigo = new(75, 0, 130, 255);
        public static readonly Color Violet = new(238, 130, 238, 255);
        public static readonly Color Transparent = new(0, 0, 0, 0);
        
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
    
    // Methods
    public partial struct Color
    {
        public float Grayscale
        {
            get
            {
                return 0.299f * R + 0.587f * G + 0.114f * B;
            }
        }

        public Color Gamma
        {
            get
            {
                float r = R / 255f;
                float g = G / 255f;
                float b = B / 255f;

                r = r <= 0.0031308f ? r * 12.92f : 1.055f * Maths.Pow(r, 1f / 2.4f) - 0.055f;
                g = g <= 0.0031308f ? g * 12.92f : 1.055f * Maths.Pow(g, 1f / 2.4f) - 0.055f;
                b = b <= 0.0031308f ? b * 12.92f : 1.055f * Maths.Pow(b, 1f / 2.4f) - 0.055f;

                return new Color
                (
                    RoundToByte(r * 255f),
                    RoundToByte(g * 255f),
                    RoundToByte(b * 255f),
                    A
                );
            }
        }

        public Color Linear
        {
            get
            {
                float r = R / 255f;
                float g = G / 255f;
                float b = B / 255f;

                r = r <= 0.04045f ? r / 12.92f : Maths.Pow((r + 0.055f) / 1.055f, 2.4f);
                g = g <= 0.04045f ? g / 12.92f : Maths.Pow((g + 0.055f) / 1.055f, 2.4f);
                b = b <= 0.04045f ? b / 12.92f : Maths.Pow((b + 0.055f) / 1.055f, 2.4f);

                return new Color
                (
                    RoundToByte(r * 255f),
                    RoundToByte(g * 255f),
                    RoundToByte(b * 255f),
                    A
                );
            }
        }
        
        public static Color Lerp(Color a, Color b, float t)
        {
            return new Color
            (
                RoundToByte(Maths.Lerp(a.R, b.R, t)),
                RoundToByte(Maths.Lerp(a.G, b.G, t)),
                RoundToByte(Maths.Lerp(a.B, b.B, t)),
                RoundToByte(Maths.Lerp(a.A, b.A, t))
            );
        }

        public static Color LerpUnclamped(Color a, Color b, float t)
        {
            return new Color
            (
                RoundToByte(Maths.LerpUnclamped(a.R, b.R, t)),
                RoundToByte(Maths.LerpUnclamped(a.G, b.G, t)),
                RoundToByte(Maths.LerpUnclamped(a.B, b.B, t)),
                RoundToByte(Maths.LerpUnclamped(a.A, b.A, t))
            );
        }

        public static Color HSVToRGB(float h, float s, float v, bool hdr = false)
        {
            h = h % 1f;
            float r = 0f, g = 0f, b = 0f;

            float i = Maths.Floor(h * 6f);
            float f = h * 6f - i;
            float p = v * (1f - s);
            float q = v * (1f - f * s);
            float t = v * (1f - (1f - f) * s);

            switch ((int)i % 6)
            {
                case 0: r = v; g = t; b = p; break;
                case 1: r = q; g = v; b = p; break;
                case 2: r = p; g = v; b = t; break;
                case 3: r = p; g = q; b = v; break;
                case 4: r = t; g = p; b = v; break;
                case 5: r = v; g = p; b = q; break;
            }

            return new Color
            (
                RoundToByte(r * 255f),
                RoundToByte(g * 255f),
                RoundToByte(b * 255f),
                255
            );
        }

        public static void RGBToHSV(Color color, out float h, out float s, out float v)
        {
            float r = color.R / 255f;
            float g = color.G / 255f;
            float b = color.B / 255f;

            float max = Maths.Max(Maths.Max(r, g), b);
            float min = Maths.Min(Maths.Min(r, g), b);
            v = max;

            float delta = max - min;
            s = max == 0f ? 0f : delta / max;

            if (Maths.Approximately(delta, 0f))
            {
                h = 0f;
                return;
            }

            if (Maths.Approximately(max, r))
            {
                h = (g - b) / delta % 6f;
            }
            else if (Maths.Approximately(max, g))
            {
                h = (b - r) / delta + 2f;
            }
            else
            {
                h = (r - g) / delta + 4f;
            }

            h /= 6f;

            if (h < 0f)
            {
                h += 1f;
            }
        }
        
        public void Set(byte r, byte g, byte b, byte a)
        {
            this.R = r;
            this.G = g;
            this.B = b;
            this.A = a;
        }
    }

    // Operators
    public partial struct Color
    {
        public static Color operator +(Color a, Color b)
        {
            return new Color
            (
                RoundToByte(a.R + b.R),
                RoundToByte(a.G + b.G),
                RoundToByte(a.B + b.B),
                RoundToByte(a.A + b.A)
            );
        }

        public static Color operator -(Color a, Color b)
        {
            return new Color
            (
                RoundToByte(a.R - b.R),
                RoundToByte(a.G - b.G),
                RoundToByte(a.B - b.B),
                RoundToByte(a.A - b.A)
            );
        }
        
        public static Color operator -(Color c)
        {
            return new Color
            (
                (byte)(255 - c.R),
                (byte)(255 - c.G),
                (byte)(255 - c.B),
                (byte)(255 - c.A)
            );
        }
        
        public static Color operator *(Color a, Color b)
        {
            return new Color
            (
                RoundToByte(a.R * b.R / 255f),
                RoundToByte(a.G * b.G / 255f),
                RoundToByte(a.B * b.B / 255f),
                RoundToByte(a.A * b.A / 255f)
            );
        }
        
        public static Color operator *(Color c, float f)
        {
            return new Color
            (
                RoundToByte(c.R * f),
                RoundToByte(c.G * f),
                RoundToByte(c.B * f),
                RoundToByte(c.A * f)
            );
        }

        public static Color operator *(float f, Color c)
        {
            return new Color
            (
                RoundToByte(c.R * f),
                RoundToByte(c.G * f),
                RoundToByte(c.B * f),
                RoundToByte(c.A * f)
            );
        }
        
        public static Color operator /(Color a, float f)
        {
            return new Color
            (
                RoundToByte(a.R / f),
                RoundToByte(a.G / f),
                RoundToByte(a.B / f),
                RoundToByte(a.A / f)
            );
        }
        
        public static bool operator ==(Color a, Color b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Color a, Color b)
        {
            return !a.Equals(b);
        }
        
        public bool Equals(Color c)
        {
            return R == c.R && G == c.G && B == c.B && A == c.A;
        }

        public override bool Equals(object c)
        {
            if (c is Color other)
            {
                return Equals(other);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(R, G, B, A);
        }

        public override string ToString()
        {
            return $"({R}, {G}, {B}, {A})";
        }
    }
}