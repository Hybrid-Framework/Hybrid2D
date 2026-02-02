using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    // Color
    [StructLayout(LayoutKind.Sequential)]
    public partial struct Color
    {
        // Red Value (0 - 1)
        private float _r;
        public float r
        {
            get => _r;
            set => _r = Maths.Clamp01(value);
        }
        
        // Green Value (0 - 1)
        private float _g;
        public float g
        {
            get => _g;
            set => _g = Maths.Clamp01(value);
        }
        
        // Blue Value (0 - 1)
        private float _b;
        public float b
        {
            get => _b;
            set => _b = Maths.Clamp01(value);
        }
        
        // Alpha Value (0 - 1)
        private float _a;
        public float a
        {
            get => _a;
            set => _a = Maths.Clamp01(value);
        }

        // Constructor
        public Color(float r, float g, float b, float a = 1f)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }
        
        // Constructor
        public Color()
        {
            
        }
    }

    // SDL
    public partial struct Color
    {
        internal static SDL.Color ToSDLColor(Color color)
        {
            return new SDL.Color
            (
                color.r,
                color.g,
                color.b,
                color.a
            );
        }

        internal static SDL.Color32 ToSDLColor32(Color color)
        {
            return new SDL.Color32
            (
                (byte)(Math.Clamp(color.r, 0f, 1f) * 255f + 0.5f),
                (byte)(Math.Clamp(color.g, 0f, 1f) * 255f + 0.5f),
                (byte)(Math.Clamp(color.b, 0f, 1f) * 255f + 0.5f),
                (byte)(Math.Clamp(color.a, 0f, 1f) * 255f + 0.5f)
            );
        }

        internal static Color FromSDLColor(SDL.Color color)
        {
            return new Color
            (
                color.r,
                color.g,
                color.b,
                color.a
            );
        }
        
        internal static Color FromSDLColor32(SDL.Color32 color)
        {
            return new Color
            (
                color.r / 255f,
                color.g / 255f,
                color.b / 255f,
                color.a / 255f
            );
        }
    }
}