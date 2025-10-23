using System;

namespace Hybrid
{
    // Vector4
    public partial struct Vector4 : IEquatable<Vector4>
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
    }

    // Properties
    public partial struct Vector4
    {
        public static readonly Vector4 positiveInfinity = new(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
        public static readonly Vector4 negativeInfinity = new(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
        public static readonly Vector4 zero = new(0, 0, 0, 0);
        public static readonly Vector4 one = new(1, 1, 1, 1);
        
        public static float epsilon = 1e-5f;
        
        public float magnitude
        {
            get
            {
                return MathF.Sqrt(sqrMagnitude);
            }
        }
        
        public float sqrMagnitude
        {
            get
            {
                return x * x + y * y + z * z + w * w;
            }
        }
        
        public Vector4 normalized
        {
            get
            {
                float mag = magnitude;
                
                if (mag > epsilon)
                {
                    return this / mag;
                }
                
                return zero;
            }
        }
    }
    
    // Methods
    public partial struct Vector4
    {
        public void Set(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.y = y;
        }
        
        public void Normalize()
        {
            float mag = magnitude;
            
            if (mag > epsilon)
            {
                x /= mag;
                y /= mag;
                z /= mag;
                w /= mag;
            }
            else
            {
                x = y = z = w = 0f;
            }
        }
        
        public static float Distance(Vector4 a, Vector4 b)
        {
            return (a - b).magnitude;
        }
        
        public static float Dot(Vector4 a, Vector4 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
        }

        public static Vector4 Lerp(Vector4 a, Vector4 b, float t)
        {
            t = Math.Clamp(t, 0f, 1f);
            
            return a + (b - a) * t;
        }

        public static Vector4 LerpUnclamped(Vector4 a, Vector4 b, float t)
        {
            return a + (b - a) * t;
        }

        public static Vector4 Max(Vector4 a, Vector4 b)
        {
            return new Vector4
            (
                MathF.Max(a.x, b.x),
                MathF.Max(a.y, b.y),
                MathF.Max(a.z, b.z),
                MathF.Max(a.w, b.w)
            );
        }

        public static Vector4 Min(Vector4 a, Vector4 b)
        {
            return new Vector4
            (
                MathF.Min(a.x, b.x),
                MathF.Min(a.y, b.y),
                MathF.Min(a.z, b.z),
                MathF.Min(a.w, b.w)
            );
        }

        public static Vector4 MoveTowards(Vector4 a, Vector4 b, float t)
        {
            Vector4 delta = b - a;
            float dist = delta.magnitude;

            if (dist <= t || dist < epsilon)
            {
                return b;
            }

            return a + delta / dist * t;
        }

        public static Vector4 Normalize(Vector4 vector)
        {
            float mag = vector.magnitude;
            
            if (mag > epsilon)
            {
                return vector / mag;
            }

            return zero;
        }

        public static Vector4 Project(Vector4 vector, Vector4 normal)
        {
            float sqrMag = normal.sqrMagnitude;
            
            if (sqrMag < epsilon)
            {
                return zero;
            }
            
            return normal * (Dot(vector, normal) / sqrMag);
        }

        public static Vector4 Scale(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
        }
        
        public static bool Approximately(Vector4 a, Vector4 b, float tolerance = 1e-5f)
        {
            return MathF.Abs(a.x - b.x) <= tolerance &&
                   MathF.Abs(a.y - b.y) <= tolerance &&
                   MathF.Abs(a.z - b.z) <= tolerance &&
                   MathF.Abs(a.w - b.w) <= tolerance;
        }
    }
    
    
    // Operators
    public partial struct Vector4
    {
        public static implicit operator Vector4(Color color)
        {
            return new Vector4(color.r / 255f, color.g / 255f, color.b / 255f, color.a / 255f);
        }
        
        public static implicit operator Vector4(Vector2 vector)
        {
            return new(vector.x, vector.y, 0f, 0f);
        }
        
        public static implicit operator Vector4(Vector3 vector)
        {
            return new(vector.x, vector.y, vector.z, 0f);
        }

        public static Vector4 operator + (Vector4 a, Vector4 b)
        {
            return new(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        }
        
        public static Vector4 operator - (Vector4 a, Vector4 b)
        {
            return new(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
        }
        
        public static Vector4 operator - (Vector4 a)
        {
            return new(-a.x, -a.y, -a.z, -a.w);
        }

        public static Vector4 operator * (Vector4 a, float value)
        {
            return new(a.x * value, a.y * value, a.z * value, a.w * value);
        }
        
        public static Vector4 operator * (float value, Vector4 a)
        {
            return new(a.x * value, a.y * value, a.z * value, a.w * value);
        }

        public static Vector4 operator / (Vector4 a, float d)
        {
            if (MathF.Abs(d) < epsilon)
            {
                return zero;
            }
            
            return new(a.x / d, a.y / d, a.z / d, a.w / d);
        }

        public static bool operator == (Vector4 a, Vector4 b)
        {
            return Approximately(a, b);
        }

        public static bool operator != (Vector4 a, Vector4 b)
        {
            return !Approximately(a, b);
        }
        
        public override bool Equals(object? obj)
        {
            return obj is Vector4 vector && Equals(vector);
        }
        
        public bool Equals(Vector4 vector)
        {
            return this == vector;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y, z, w);
        }

        public override string ToString()
        {
            return $"({x:F3}, {y:F3}, {z:F3}, {w:F3})";
        }
    }
}