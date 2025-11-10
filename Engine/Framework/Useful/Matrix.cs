using System;

namespace Hybrid
{
    // Matrix
    public partial struct Matrix : IEquatable<Matrix>
    {
        public static readonly Matrix Identity = new(1, 0, 0, 1, 0, 0);
        public static readonly Matrix Zero = new(0, 0, 0, 0, 0, 0);

        public float M11, M12; // M13 (not required)
        public float M21, M22; // M23 (not required)
        public float M31, M32; // M33 (not required)
        

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

    // Operators
    public partial struct Matrix
    {
        public static Matrix operator *(Matrix a, Matrix b)
        {
            return new Matrix
            (
                a.M11 * b.M11 + a.M12 * b.M21,
                a.M11 * b.M12 + a.M12 * b.M22,
            
                a.M21 * b.M11 + a.M22 * b.M21,
                a.M21 * b.M12 + a.M22 * b.M22,
            
                a.M31 * b.M11 + a.M32 * b.M21 + b.M31,
                a.M31 * b.M12 + a.M32 * b.M22 + b.M32
            );
        }

        public static Vector4 operator *(Matrix m, Vector4 v)
        {
            return new Vector4
            (
                m.M11 * v.X + m.M12 * v.Y + m.M31 * v.W,
                m.M21 * v.X + m.M22 * v.Y + m.M32 * v.W,
                v.Z,
                v.W
            );
        }

        public static bool operator ==(Matrix a, Matrix b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Matrix a, Matrix b)
        {
            return !a.Equals(b);
        }
        
        public bool Equals(Matrix m)
        {
            return Maths.Approximately(M11, m.M11) &&
                   Maths.Approximately(M12, m.M12) &&
                   Maths.Approximately(M21, m.M21) &&
                   Maths.Approximately(M22, m.M22) &&
                   Maths.Approximately(M31, m.M31) &&
                   Maths.Approximately(M32, m.M32);
        }

        public override bool Equals(object m)
        {
            if (m is Matrix other)
            {
                return Equals(other);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(M11, M12, M21, M22, M31, M32);
        }

        public override string ToString()
        {
            return $"[{M11}, {M12}, 0]\n[{M21}, {M22}, 0]\n[{M31}, {M32}, 1]";
        }
    }
}