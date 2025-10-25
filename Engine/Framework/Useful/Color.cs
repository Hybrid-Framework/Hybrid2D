using System;

namespace Hybrid
{
    // Color
    public partial struct Color
    {
        public byte R;
        public byte G;
        public byte B;
        public byte A;

        public Color(byte R, byte G, byte B, byte A)
        {
            this.R = R;
            this.G = G;
            this.B = B;
            this.A = A;
        }
    }
}