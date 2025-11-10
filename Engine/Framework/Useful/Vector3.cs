using System;

namespace Hybrid
{
    // Vector3
    public partial struct Vector3 : IEquatable<Vector3>
    {
        public static readonly Vector3 PositiveInfinity = new(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
        public static readonly Vector3 NegativeInfinity = new(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
        
        public static readonly Vector3 Zero = new(0, 0, 0);
        public static readonly Vector3 One = new(1, 1, 1);
        
        public static readonly Vector3 Up = new(0, 1, 0);
        public static readonly Vector3 Down = new(0, -1, 0);
        public static readonly Vector3 Left = new(-1, 0, 0);
        public static readonly Vector3 Right = new(1, 0, 0);
        public static readonly Vector3 Forward = new(0, 0, 1);
        public static readonly Vector3 Back = new(0, 0, -1);
        
        public float X;
        public float Y;
        public float Z;
        

        public Vector3(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Vector3()
        {
            
        }
    }
    
    // Operators
    public partial struct Vector3
    {
        public static implicit operator Vector3(Vector2 v)
        {
            return new Vector3(v.X, v.Y, 0);
        }
        
        public static implicit operator Vector3(Vector4 v)
        {
            return new Vector3(v.X, v.Y, v.Z);
        }
        
        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        
        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Vector3 operator -(Vector3 v)
        {
            return new(-v.X, -v.Y, -v.Z);
        }

        public static Vector3 operator *(Vector3 a, Vector3 b)
        {
            return new(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        }

        public static Vector3 operator *(Vector3 v, float value)
        {
            return new(v.X * value, v.Y * value, v.Z * value);
        }

        public static Vector3 operator *(float value, Vector3 v)
        {
            return new(v.X * value, v.Y * value, v.Z * value);
        }

        public static Vector3 operator /(Vector3 a, Vector3 b)
        {
            return new(a.X / b.X, a.Y / b.Y, a.Z / b.Z);
        }

        public static Vector3 operator /(Vector3 v, float value)
        {
            return new(v.X / value, v.Y / value, v.Z / value);
        }

        public static bool operator ==(Vector3 a, Vector3 b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Vector3 a, Vector3 b)
        {
            return !a.Equals(b);
        }
        
        public bool Equals(Vector3 v)
        {
            return Maths.Approximately(X, v.X) && 
                   Maths.Approximately(Y, v.Y) &&
                   Maths.Approximately(Z, v.Z);
        }

        public override bool Equals(object v)
        {
            if (v is Vector3 other)
            {
                return Equals(other);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }
    }
}