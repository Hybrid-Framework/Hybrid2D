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

    public partial struct Vector4
    {
        public float Magnitude
        {
            get
            {
                return Maths.Sqrt(SqrMagnitude);
            }
        }

        public float SqrMagnitude
        {
            get
            {
                return (X * X + Y * Y + Z * Z + W * W);
            }
        }

        public Vector4 Normalized
        {
            get
            {
                float mag = Magnitude;

                if (mag > Maths.Epsilon)
                {
                    return this / mag;
                }
                
                return Zero;
            }
        }

        public static float Distance(Vector4 a, Vector4 b)
        {
            return (a - b).Magnitude;
        }

        public static float Dot(Vector4 a, Vector4 b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z + a.W * b.W;
        }

        public static Vector4 Lerp(Vector4 a, Vector4 b, float t)
        {
            return new Vector4
            (
                Maths.Lerp(a.X, b.X, t),
                Maths.Lerp(a.Y, b.Y, t),
                Maths.Lerp(a.Z, b.Z, t),
                Maths.Lerp(a.W, b.W, t)
            );
        }

        public static Vector4 LerpUnclamped(Vector4 a, Vector4 b, float t)
        {
            return new Vector4
            (
                Maths.LerpUnclamped(a.X, b.X, t),
                Maths.LerpUnclamped(a.Y, b.Y, t),
                Maths.LerpUnclamped(a.Z, b.Z, t),
                Maths.LerpUnclamped(a.W, b.W, t)
            );
        }

        public static Vector4 Max(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4
            (
                Maths.Max(lhs.X, rhs.X),
                Maths.Max(lhs.Y, rhs.Y),
                Maths.Max(lhs.Z, rhs.Z),
                Maths.Max(lhs.W, rhs.W)
            );
        }

        public static Vector4 Min(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4
            (
                Maths.Min(lhs.X, rhs.X),
                Maths.Min(lhs.Y, rhs.Y),
                Maths.Min(lhs.Z, rhs.Z),
                Maths.Min(lhs.W, rhs.W)
            );
        }

        public static Vector4 MoveTowards(Vector4 current, Vector4 target, float maxDistanceDelta)
        {
            Vector4 delta = target - current;
            float distance = delta.SqrMagnitude;

            if (distance == 0f || (maxDistanceDelta >= 0f && distance <= maxDistanceDelta * maxDistanceDelta))
            {
                return target;
            }

            float dist = Maths.Sqrt(distance);
            return current + delta / dist * maxDistanceDelta;
        }
        
        public void Normalize()
        {
            float mag = Magnitude;
            
            if (mag > Maths.Epsilon)
            {
                X /= mag;
                Y /= mag;
                Z /= mag;
                W /= mag;
            }
            else
            {
                X = 0;
                Y = 0;
                Z = 0;
                W = 0;
            }
        }

        public void Set(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
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