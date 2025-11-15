using System;

namespace Hybrid
{
    // Matrix
    public partial struct Matrix
    {
        public static readonly Matrix Identity = new(1, 0, 0, 1, 0, 0);
        public static readonly Matrix Zero = new(0, 0, 0, 0, 0, 0);

        public float M11, M12; // M13 (0)
        public float M21, M22; // M23 (0)
        public float M31, M32; // M33 (1)
        

        public Matrix(float m11, float m12, float m21, float m22, float m31, float m32)
        {
            this.M11 = m11;
            this.M12 = m12;
            
            this.M21 = m21;
            this.M22 = m22;
            
            this.M31 = m31;
            this.M32 = m32;
        }

        public Matrix()
        {
            
        }
    }
}