using System;

namespace Hybrid
{
    // Vector4
    public partial struct Vector4 : IEquatable<Vector4>
    {
        public static readonly Vector4 PositiveInfinity = new(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
        public static readonly Vector4 NegativeInfinity = new(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
        
        public static readonly Vector4 Zero = new(0, 0, 0, 0);
        public static readonly Vector4 One = new(1, 1, 1, 1);
        
        public float X;
        public float Y;
        public float Z;
        public float W;
        

        public Vector4(float x, float y, float z, float w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }

        public Vector4()
        {
            
        }
    }
    
    // Operators
    public partial struct Vector4
    {
        public static implicit operator Vector4(Vector2 v)
        {
            return new Vector4(v.X, v.Y, 0, 0);
        }
        
        public static implicit operator Vector4(Vector3 v)
        {
            return new Vector4(v.X, v.Y, v.Z, 0);
        }
        
        public static Vector4 operator +(Vector4 a, Vector4 b)
        {
            return new(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
        }
        
        public static Vector4 operator -(Vector4 a, Vector4 b)
        {
            return new(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
        }

        public static Vector4 operator -(Vector4 v)
        {
            return new(-v.X, -v.Y, -v.Z, -v.W);
        }

        public static Vector4 operator *(Vector4 a, Vector4 b)
        {
            return new(a.X * b.X, a.Y * b.Y, a.Z * b.Z, a.W * b.W);
        }

        public static Vector4 operator *(Vector4 v, float value)
        {
            return new(v.X * value, v.Y * value, v.Z * value, v.W * value);
        }

        public static Vector4 operator *(float value, Vector4 v)
        {
            return new(v.X * value, v.Y * value, v.Z * value, v.W * value);
        }

        public static Vector4 operator /(Vector4 a, Vector4 b)
        {
            return new(a.X / b.X, a.Y / b.Y, a.Z / b.Z, a.W / b.W);
        }

        public static Vector4 operator /(Vector4 v, float value)
        {
            return new(v.X / value, v.Y / value, v.Z / value, v.W / value);
        }

        public static bool operator ==(Vector4 a, Vector4 b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Vector4 a, Vector4 b)
        {
            return !a.Equals(b);
        }
        
        public bool Equals(Vector4 v)
        {
            return Maths.Approximately(X, v.X) && 
                   Maths.Approximately(Y, v.Y) &&
                   Maths.Approximately(Z, v.Z) &&
                   Maths.Approximately(W, v.W);
        }

        public override bool Equals(object v)
        {
            if (v is Vector4 other)
            {
                return Equals(other);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z, W);
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z}, {W})";
        }
    }
}