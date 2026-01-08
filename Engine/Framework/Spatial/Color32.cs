using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    // Color 32
    [StructLayout(LayoutKind.Sequential)]
    public struct Color32
    {
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
}