using System;

namespace Hybrid
{
    // Color
    public partial struct Color : IEquatable<Color>
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
    
    // Properties
    public partial struct Color
    {
        public static readonly Color CornflowerBlue = new(100, 149, 237, 255);
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
        
        public static float Epsilon = 1e-5f;
        
        public float grayscale
        {
            get
            {
                float rf = r / 255f;
                float gf = g / 255f;
                float bf = b / 255f;

                return 0.2126f * rf + 0.7152f * gf + 0.0722f * bf;
            }
        }
        
        public Color linear
        {
            get
            {
                float rf = SRGBToLinear(r / 255f);
                float gf = SRGBToLinear(g / 255f);
                float bf = SRGBToLinear(b / 255f);
                
                return new Color
                (
                    (byte)Math.Clamp(MathF.Round(rf * 255f), 0, 255),
                    (byte)Math.Clamp(MathF.Round(gf * 255f), 0, 255),
                    (byte)Math.Clamp(MathF.Round(bf * 255f), 0, 255),
                    a
                );
            }
        }
        
        public Color gamma
        {
            get
            {
                float rf = LinearToSRGB(r / 255f);
                float gf = LinearToSRGB(g / 255f);
                float bf = LinearToSRGB(b / 255f);
                
                return new Color
                (
                    (byte)Math.Clamp(MathF.Round(rf * 255f), 0, 255),
                    (byte)Math.Clamp(MathF.Round(gf * 255f), 0, 255),
                    (byte)Math.Clamp(MathF.Round(bf * 255f), 0, 255),
                    a
                );
            }
        }
    }
    
    // Methods
    public partial struct Color
    {
        public void Set(byte r, byte g, byte b, byte a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }
        
        private static float SRGBToLinear(float c)
        {
            return (c <= 0.04045f) ? c / 12.92f : MathF.Pow((c + 0.055f) / 1.055f, 2.4f);
        }

        private static float LinearToSRGB(float c)
        {
            return (c <= 0.0031308f) ? 12.92f * c : 1.055f * MathF.Pow(c, 1f / 2.4f) - 0.055f;
        }
        
        public static Color HSVToRGB(float h, float s, float v, byte alpha = 255)
        {
            h = h % 360f;
            if (h < 0) h += 360f;

            s = Math.Clamp(s, 0f, 1f);
            v = Math.Clamp(v, 0f, 1f);

            float c = v * s;
            float x = c * (1f - MathF.Abs((h / 60f) % 2 - 1f));
            float m = v - c;

            float r1 = 0, g1 = 0, b1 = 0;
            if (h < 60) { r1 = c; g1 = x; b1 = 0; }
            else if (h < 120) { r1 = x; g1 = c; b1 = 0; }
            else if (h < 180) { r1 = 0; g1 = c; b1 = x; }
            else if (h < 240) { r1 = 0; g1 = x; b1 = c; }
            else if (h < 300) { r1 = x; g1 = 0; b1 = c; }
            else { r1 = c; g1 = 0; b1 = x; }

            byte R = (byte)MathF.Round((r1 + m) * 255f);
            byte G = (byte)MathF.Round((g1 + m) * 255f);
            byte B = (byte)MathF.Round((b1 + m) * 255f);

            return new Color(R, G, B, alpha);
        }

        public static void RGBToHSV(Color color, out float h, out float s, out float v)
        {
            float r = color.r / 255f;
            float g = color.g / 255f;
            float b = color.b / 255f;

            float max = MathF.Max(r, MathF.Max(g, b));
            float min = MathF.Min(r, MathF.Min(g, b));
            float delta = max - min;

            v = max;
            s = (max <= Epsilon) ? 0f : delta / max;

            if (delta < Epsilon)
            {
                h = 0f;
            }
            else if (max == r)
            {
                h = 60f * (((g - b) / delta) % 6f);
            }
            else if (max == g)
            {
                h = 60f * (((b - r) / delta) + 2f);
            }
            else
            {
                h = 60f * (((r - g) / delta) + 4f);
            }

            if (h < 0) h += 360f;
        }
        
        public static Color Lerp(Color a, Color b, float t)
        {
            t = Math.Clamp(t, 0f, 1f);
            
            return LerpUnclamped(a, b, t);
        }

        public static Color LerpUnclamped(Color a, Color b, float t)
        {
            return new Color
            (
                (byte)Math.Clamp(MathF.Round(a.r + (b.r - a.r) * t), 0, 255),
                (byte)Math.Clamp(MathF.Round(a.g + (b.g - a.g) * t), 0, 255),
                (byte)Math.Clamp(MathF.Round(a.b + (b.b - a.b) * t), 0, 255),
                (byte)Math.Clamp(MathF.Round(a.a + (b.a - a.a) * t), 0, 255)
            );
        }
        
        public static bool Approximately(Color a, Color b, int tolerance = 1)
        {
            return MathF.Abs(a.r - b.r) <= tolerance &&
                   MathF.Abs(a.g - b.g) <= tolerance &&
                   MathF.Abs(a.b - b.b) <= tolerance &&
                   MathF.Abs(a.a - b.a) <= tolerance;
        }
    }
    
    // Operators
    public partial struct Color
    {
        public static implicit operator Color(Vector2 vector)
        {
            return new Color
            (
                (byte)Math.Clamp(MathF.Ceiling(vector.x * 255f), 0, 255),
                (byte)Math.Clamp(MathF.Ceiling(vector.y * 255f), 0, 255),
                0,
                255
            );
        }
        
        public static implicit operator Color(Vector3 vector)
        {
            return new Color
            (
                (byte)Math.Clamp(MathF.Ceiling(vector.x * 255f), 0, 255),
                (byte)Math.Clamp(MathF.Ceiling(vector.y * 255f), 0, 255),
                (byte)Math.Clamp(MathF.Ceiling(vector.z * 255f), 0, 255),
                255
            );
        }
        
        public static implicit operator Color(Vector4 vector)
        {
            return new Color
            (
                (byte)Math.Clamp(MathF.Ceiling(vector.x * 255f), 0, 255),
                (byte)Math.Clamp(MathF.Ceiling(vector.y * 255f), 0, 255),
                (byte)Math.Clamp(MathF.Ceiling(vector.z * 255f), 0, 255),
                (byte)Math.Clamp(MathF.Ceiling(vector.w * 255f), 0, 255)
            );
        }
        
        public static Color operator + (Color a, Color b)
        {
            return new Color
            (
                (byte)Math.Clamp(a.r + b.r, 0, 255),
                (byte)Math.Clamp(a.g + b.g, 0, 255),
                (byte)Math.Clamp(a.b + b.b, 0, 255),
                (byte)Math.Clamp(a.a + b.a, 0, 255)
            );
        }

        public static Color operator - (Color a, Color b)
        {
            return new Color
            (
                (byte)Math.Clamp(a.r - b.r, 0, 255),
                (byte)Math.Clamp(a.g - b.g, 0, 255),
                (byte)Math.Clamp(a.b - b.b, 0, 255),
                (byte)Math.Clamp(a.a - b.a, 0, 255)
            );
        }

        public static Color operator * (Color a, Color b)
        {
            return new Color
            (
                (byte)Math.Clamp(a.r * b.r / 255, 0, 255),
                (byte)Math.Clamp(a.g * b.g / 255, 0, 255),
                (byte)Math.Clamp(a.b * b.b / 255, 0, 255),
                (byte)Math.Clamp(a.a * b.a / 255, 0, 255)
            );
        }

        public static Color operator / (Color a, float value)
        {
            if (Math.Abs(value) < Epsilon) return Transparent;

            return new Color
            (
                (byte)Math.Clamp(MathF.Round(a.r / value), 0, 255),
                (byte)Math.Clamp(MathF.Round(a.g / value), 0, 255),
                (byte)Math.Clamp(MathF.Round(a.b / value), 0, 255),
                (byte)Math.Clamp(MathF.Round(a.a / value), 0, 255)
            );
        }

        public static bool operator == (Color a, Color b)
        {
            return Approximately(a, b);
        }

        public static bool operator != (Color a, Color b)
        {
            return !Approximately(a, b);
        }

        public override bool Equals(object? obj)
        {
            return obj is Color other && Equals(other);
        }
        
        public bool Equals(Color other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(r, g, b, a);
        }

        public override string ToString()
        {
            return $"({r}, {g}, {b}, {a})";
        }
    }
}