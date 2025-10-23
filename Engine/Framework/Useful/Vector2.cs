using System;

namespace Hybrid
{
    // Vector2
    public partial struct Vector2 : IEquatable<Vector2>
    {
        public float x;
        public float y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
    
    // Properties
    public partial struct Vector2
    {
        public static readonly Vector2 PositiveInfinity = new(float.PositiveInfinity, float.PositiveInfinity);
        public static readonly Vector2 NegativeInfinity = new(float.NegativeInfinity, float.NegativeInfinity);

        public static readonly Vector2 Zero = new(0, 0);
        public static readonly Vector2 One = new(1, 1);

        public static readonly Vector2 Up = new(0, 1);
        public static readonly Vector2 Down = new(0, -1);
        public static readonly Vector2 Left = new(-1, 0);
        public static readonly Vector2 Right = new(1, 0);

        public static float Epsilon = 1.5e-5f;


        public float magnitude
        {
            get { return MathF.Sqrt(x * x + y * y); }
        }

        public float sqrMagnitude
        {
            get { return x * x + y * y; }
        }

        public Vector2 normalized
        {
            get
            {
                float mag = magnitude;

                if (mag > Epsilon)
                {
                    return this / mag;
                }

                return Zero;
            }
        }
    }
    
    // Methods
    public partial struct Vector2
    {
        public static float Angle(Vector2 from, Vector2 to)
        {
            float value = MathF.Sqrt(from.sqrMagnitude * to.sqrMagnitude);

            if (value < Epsilon)
            {
                return 0f;
            }

            float cos = Math.Clamp(Dot(from, to) / value, -1f, 1f);
            return MathF.Acos(cos) * (180f / MathF.PI);
        }
        
        public static Vector2 ClampMagnitude(Vector2 vector, float max)
        {
            float mag = vector.magnitude;

            if (mag > max)
            {
                return vector / mag * max;
            }

            return vector;
        }
        
        public static float Distance(Vector2 a, Vector2 b)
        {
            return (a - b).magnitude;
        }
        
        public static float Dot(Vector2 a, Vector2 b)
        {
            return a.x * b.x + a.y * b.y;
        }
        
        public static Vector2 Lerp(Vector2 a, Vector2 b, float t)
        {
            t = Math.Clamp(t, 0f, 1f);

            return a + (b - a) * t;
        }

        public static Vector2 LerpUnclamped(Vector2 a, Vector2 b, float t)
        {
            return a + (b - a) * t;
        }
        
        public static Vector2 Max(Vector2 a, Vector2 b)
        {
            return new Vector2
            (
                MathF.Max(a.x, b.x),
                MathF.Max(a.y, b.y)
            );
        }

        public static Vector2 Min(Vector2 a, Vector2 b)
        {
            return new Vector2
            (
                MathF.Min(a.x, b.x),
                MathF.Min(a.y, b.y)
            );
        }

        public static Vector2 MoveTowards(Vector2 a, Vector2 b, float t)
        {
            Vector2 delta = b - a;
            float mag = delta.magnitude;

            if (mag <= t || mag < Epsilon)
            {
                return b;
            }

            return a + delta / mag * t;
        }
        
        public static Vector2 Normalize(Vector2 vector)
        {
            float mag = vector.magnitude;

            if (mag > Epsilon)
            {
                return vector / mag;
            }

            return Zero;
        }

        public void Normalize()
        {
            float mag = magnitude;

            if (mag > Epsilon)
            {
                x /= mag;
                y /= mag;
            }
            else
            {
                x = 0f;
                y = 0f;
            }
        }

        public static Vector2 Perpendicular(Vector2 vector)
        {
            return new(-vector.y, vector.x);
        }
        
        public static Vector2 Reflect(Vector2 direction, Vector2 normal)
        {
            return direction - 2f * Dot(direction, normal) * normal;
        }

        public static Vector2 Scale(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x * b.x, a.y * b.y);
        }

        public static float SignedAngle(Vector2 from, Vector2 to)
        {
            float sign = MathF.Sign(from.x * to.y - from.y * to.x);

            return Angle(from, to) * sign;
        }
    }
    
    // Operators
    public partial struct Vector2
    {
        public static implicit operator Vector2(Color c)
        {
            return new Vector2(c.r / 255f, c.g / 255f);
        }
        
        public static implicit operator Vector2(Vector3 vector)
        {
            return new(vector.x, vector.y);
        }
        
        public static implicit operator Vector2(Vector4 vector)
        {
            return new(vector.x, vector.y);
        }
        
        public static Vector2 operator + (Vector2 a, Vector2 b)
        {
            return new(a.x + b.x, a.y + b.y);
        }
        
        public static Vector2 operator - (Vector2 a, Vector2 b)
        {
            return new(a.x - b.x, a.y - b.y);
        }
        
        public static Vector2 operator - (Vector2 a)
        {
            return new(-a.x, -a.y);
        }

        public static Vector2 operator * (Vector2 a, float value)
        {
            return new(a.x * value, a.y * value);
        }
        
        public static Vector2 operator * (float value, Vector2 a)
        {
            return new(a.x * value, a.y * value);
        }

        public static Vector2 operator / (Vector2 a, float d)
        {
            if (MathF.Abs(d) < Epsilon) return Zero;
            
            return new(a.x / d, a.y / d);
        }

        public static bool operator == (Vector2 a, Vector2 b)
        {
            return MathF.Abs(a.x - b.x) <= Epsilon && MathF.Abs(a.y - b.y) <= Epsilon;
        }

        public static bool operator != (Vector2 a, Vector2 b)
        {
            return MathF.Abs(a.x - b.x) > Epsilon || MathF.Abs(a.y - b.y) > Epsilon;
        }
        
        public bool Equals(Vector2 other)
        {
            return this == other;
        }

        public override bool Equals(object? obj)
        {
            return obj is Vector2 other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }

        public override string ToString()
        {
            return $"({x:F3}, {y:F3})";
        }
    }
}