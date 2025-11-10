using System;

namespace Hybrid
{
    // Vector2
    public partial struct Vector2 : IEquatable<Vector2>
    {
        public static readonly Vector2 PositiveInfinity = new(float.PositiveInfinity, float.PositiveInfinity);
        public static readonly Vector2 NegativeInfinity = new(float.NegativeInfinity, float.NegativeInfinity);
        
        public static readonly Vector2 Zero = new(0, 0);
        public static readonly Vector2 One = new(1, 1);
        
        public static readonly Vector2 Up = new(0, 1);
        public static readonly Vector2 Down = new(0, -1);
        public static readonly Vector2 Left = new(-1, 0);
        public static readonly Vector2 Right = new(1, 0);
        
        public float X;
        public float Y;
        

        public Vector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public Vector2()
        {
            
        }
    }
    
    // Operators
    public partial struct Vector2
    {
        public static implicit operator Vector2(Vector3 v)
        {
            return new Vector2(v.X, v.Y);
        }
        
        public static implicit operator Vector2(Vector4 v)
        {
            return new Vector2(v.X, v.Y);
        }
        
        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new(a.X + b.X, a.Y + b.Y);
        }
        
        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new(a.X - b.X, a.Y - b.Y);
        }

        public static Vector2 operator -(Vector2 v)
        {
            return new(-v.X, -v.Y);
        }

        public static Vector2 operator *(Vector2 a, Vector2 b)
        {
            return new(a.X * b.X, a.Y * b.Y);
        }

        public static Vector2 operator *(Vector2 v, float value)
        {
            return new(v.X * value, v.Y * value);
        }

        public static Vector2 operator *(float value, Vector2 v)
        {
            return new(v.X * value, v.Y * value);
        }

        public static Vector2 operator /(Vector2 a, Vector2 b)
        {
            return new(a.X / b.X, a.Y / b.Y);
        }

        public static Vector2 operator /(Vector2 v, float value)
        {
            return new(v.X / value, v.Y / value);
        }

        public static bool operator ==(Vector2 a, Vector2 b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Vector2 a, Vector2 b)
        {
            return !a.Equals(b);
        }
        
        public bool Equals(Vector2 v)
        {
            return Maths.Approximately(X, v.X) && 
                   Maths.Approximately(Y, v.Y);
        }

        public override bool Equals(object v)
        {
            if (v is Vector2 other)
            {
                return Equals(other);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}