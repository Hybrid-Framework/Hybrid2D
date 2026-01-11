using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    // Color 32
    [StructLayout(LayoutKind.Sequential)]
    public partial struct Color32
    {
        public static readonly Color32 White  = new Color32(255, 255, 255, 255);
        public static readonly Color32 Black  = new Color32(0, 0, 0, 255);
        public static readonly Color32 Red    = new Color32(255, 0, 0, 255);
        public static readonly Color32 Green  = new Color32(0, 255, 0, 255);
        public static readonly Color32 Blue   = new Color32(0, 0, 255, 255);
        
        public byte r;
        public byte g;
        public byte b;
        public byte a;

        public Color32(byte r, byte g, byte b, byte a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public Color32()
        {
            
        }
    }
    
    // Operators
    public partial struct Color32
    {
        public static explicit operator Color(Color32 c32)
        {
            return new Color
            (
                c32.r / 255f,
                c32.g / 255f,
                c32.b / 255f,
                c32.a / 255f
            );
        }
    }
}