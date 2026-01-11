using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    // Color
    [StructLayout(LayoutKind.Sequential)]
    public partial struct Color
    {
        public static readonly Color White  = new Color(1f, 1f, 1f, 1f);
        public static readonly Color Black  = new Color(0f, 0f, 0f, 1f);
        public static readonly Color Red    = new Color(1f, 0f, 0f, 1f);
        public static readonly Color Green  = new Color(0f, 1f, 0f, 1f);
        public static readonly Color Blue   = new Color(0f, 0f, 1f, 1f);
        
        public float R;
        public float G;
        public float B;
        public float A;

        public Color(float r, float g, float b, float a = 1f)
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
        public static explicit operator Color32(Color c)
        {
            return new Color32
            (
                (byte)Math.Clamp((int)(c.R * 255f), 0, 255),
                (byte)Math.Clamp((int)(c.G * 255f), 0, 255),
                (byte)Math.Clamp((int)(c.B * 255f), 0, 255),
                (byte)Math.Clamp((int)(c.A * 255f), 0, 255)
            );
        }
    }
}