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
        
        public float r;
        public float g;
        public float b;
        public float a;

        public Color(float r, float g, float b, float a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public Color()
        {
            
        }
    }

    // Operators
    public partial struct Color
    {
        public static explicit operator Color32(Color c)
        {
            return new Color32
            (
                (byte)Math.Clamp((int)(c.r * 255f), 0, 255),
                (byte)Math.Clamp((int)(c.g * 255f), 0, 255),
                (byte)Math.Clamp((int)(c.b * 255f), 0, 255),
                (byte)Math.Clamp((int)(c.a * 255f), 0, 255)
            );
        }
    }
}