using System;

namespace Hybrid
{
    // Matrix
    public partial struct Matrix : IEquatable<Matrix>
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
    
    // Methods
    public partial struct Matrix
    {
        public float Determinant
        {
            get
            {
                return M11 * M22 - M12 * M21;
            }
        }
        
        public bool IsIdentity
        {
            get
            {
                return this == Identity;
            }
        }
        
        public Matrix Inverse
        {
            get
            {
                float det = Determinant;
                
                if (Maths.Approximately(det, 0f))
                {
                    return Zero;
                }

                float invDet = 1f / det;

                return new Matrix
                (
                    M22 * invDet,
                    -M12 * invDet,
                    -M21 * invDet,
                    M11 * invDet,
                    (M21 * M32 - M22 * M31) * invDet,
                    (M12 * M31 - M11 * M32) * invDet
                );
            }
        }
        
        public static Matrix CreateTranslation(Vector2 translation)
        {
            return CreateTranslation(translation.X, translation.Y);
        }
        
        public static Matrix CreateTranslation(float x, float y)
        {
            return new Matrix(1, 0, 0, 1, x, y);
        }
        
        public static Matrix CreateScale(Vector2 scale)
        {
            return CreateScale(scale.X, scale.Y);
        }

        public static Matrix CreateScale(float x, float y)
        {
            return new Matrix(x, 0, 0, y, 0, 0);
        }
        
        public static Matrix CreateRotationDegrees(float degrees)
        {
            float radians = Maths.DegreesToRadians(degrees);
            return CreateRotation(radians);
        }

        public static Matrix CreateRotation(float radians)
        {
            float cos = Maths.Cos(radians);
            float sin = Maths.Sin(radians);

            return new Matrix
            (
                cos, -sin,
                sin, cos,
                0, 0
            );
        }
        
        public static Matrix Invert(Matrix matrix)
        {
            float det = matrix.Determinant;

            if (Maths.Approximately(det, 0f))
            {
                return Zero;
            }

            float invDet = 1f / det;

            return new Matrix
            (
                matrix.M22 * invDet,
                -matrix.M12 * invDet,
                -matrix.M21 * invDet,
                matrix.M11 * invDet,
                (matrix.M21 * matrix.M32 - matrix.M22 * matrix.M31) * invDet,
                (matrix.M12 * matrix.M31 - matrix.M11 * matrix.M32) * invDet
            );
        }

        public void Set(float m11, float m12, float m21, float m22, float m31, float m32)
        {
            this.M11 = m11;
            this.M12 = m12;
            
            this.M21 = m21;
            this.M22 = m22;
            
            this.M31 = m31;
            this.M32 = m32;
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