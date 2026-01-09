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
        
        public byte R;
        public byte G;
        public byte B;
        public byte A;

        public Color32(byte r, byte g, byte b, byte a)
        {
            this.R = r;
            this.G = g;
            this.B = b;
            this.A = a;
        }
    }
    
    // Operators
    public partial struct Color32
    {
        public static explicit operator Color(Color32 c32)
        {
            return new Color
            (
                c32.R / 255f,
                c32.G / 255f,
                c32.B / 255f,
                c32.A / 255f
            );
        }
    }
}