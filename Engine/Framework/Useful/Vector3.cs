using System;

namespace Hybrid
{
    // Vector3
    public partial struct Vector3 : IEquatable<Vector3>
    {
        public float x;
        public float y;
        public float z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
    
    // Properties
    public partial struct Vector3
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

        public static float Epsilon = 1.5e-5f;


        public float magnitude
        {
            get { return MathF.Sqrt(x * x + y * y + z * z); }
        }

        public float sqrMagnitude
        {
            get { return x * x + y * y + z * z; }
        }

        public Vector3 normalized
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
    public partial struct Vector3
    {
        public static float Angle(Vector3 from, Vector3 to)
        {
            float value = MathF.Sqrt(from.sqrMagnitude * to.sqrMagnitude);

            if (value < Epsilon)
            {
                return 0f;
            }

            float cos = Math.Clamp(Dot(from, to) / value, -1f, 1f);
            return MathF.Acos(cos) * (180f / MathF.PI);
        }
        
        public static Vector3 ClampMagnitude(Vector3 vector, float max)
        {
            float mag = vector.magnitude;

            if (mag > max)
            {
                return vector / mag * max;
            }

            return vector;
        }
        
        public static Vector3 Cross(Vector3 a, Vector3 b)
        {
            return new Vector3
            (
                a.y * b.z - a.z * b.y,
                a.z * b.x - a.x * b.z,
                a.x * b.y - a.y * b.x
            );
        }
        
        public static float Distance(Vector3 a, Vector3 b)
        {
            return (a - b).magnitude;
        }
        
        public static float Dot(Vector3 a, Vector3 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }
        
        public static Vector3 Lerp(Vector3 a, Vector3 b, float t)
        {
            t = Math.Clamp(t, 0f, 1f);
            return a + (b - a) * t;
        }

        public static Vector3 LerpUnclamped(Vector3 a, Vector3 b, float t)
        {
            return a + (b - a) * t;
        }
        
        public static Vector3 Max(Vector3 a, Vector3 b)
        {
            return new Vector3
            (
                MathF.Max(a.x, b.x),
                MathF.Max(a.y, b.y),
                MathF.Max(a.z, b.z)
            );
        }

        public static Vector3 Min(Vector3 a, Vector3 b)
        {
            return new Vector3
            (
                MathF.Min(a.x, b.x),
                MathF.Min(a.y, b.y),
                MathF.Min(a.z, b.z)
            );
        }
        
        public static Vector3 MoveTowards(Vector3 a, Vector3 b, float t)
        {
            Vector3 delta = b - a;
            float dist = delta.magnitude;

            if (dist <= t || dist < Epsilon)
            {
                return b;
            }

            return a + delta / dist * t;
        }
        
        public static Vector3 Normalize(Vector3 vector)
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
                z /= mag;
            }
            else
            {
                x = 0f;
                y = 0f;
                z = 0f;
            }
        }
        
        public static Vector3 Project(Vector3 vector, Vector3 normal)
        {
            float sqrMag = normal.sqrMagnitude;

            if (sqrMag < Epsilon)
            {
                return Zero;
            }

            return normal * Dot(vector, normal) / sqrMag;
        }

        public static Vector3 ProjectOnPlane(Vector3 vector, Vector3 normal)
        {
            return vector - Project(vector, normal);
        }

        public static Vector3 Reflect(Vector3 direction, Vector3 normal)
        {
            return direction - 2f * Dot(direction, normal) * normal;
        }
        
        public static Vector3 RotateTowards(Vector3 vector, Vector3 target, float value)
        {
            float angle = Angle(vector.normalized, target.normalized);

            if (angle <= Epsilon)
            {
                return target;
            }

            float t = MathF.Min(1f, value / angle);
            return SlerpUnclamped(vector, target, t);
        }
        
        public static Vector3 Scale(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        }

        public static float SignedAngle(Vector3 from, Vector3 to, Vector3 axis)
        {
            float sign = MathF.Sign(Dot(axis, Cross(from, to)));

            return Angle(from, to) * sign;
        }
        
        public static Vector3 Slerp(Vector3 a, Vector3 b, float t)
        {
            t = Math.Clamp(t, 0f, 1f);
            
            return SlerpUnclamped(a, b, t);
        }

        public static Vector3 SlerpUnclamped(Vector3 a, Vector3 b, float t)
        {
            float magA = a.magnitude;
            float magB = b.magnitude;

            if (magA < Epsilon || magB < Epsilon)
            {
                return Lerp(a, b, t);
            }

            Vector3 aNorm = a / magA;
            Vector3 bNorm = b / magB;

            float dot = Math.Clamp(Dot(aNorm, bNorm), -1f, 1f);
            float theta = MathF.Acos(dot);

            if (theta < Epsilon)
            {
                return b * t + a * (1 - t);
            }

            float sinTheta = MathF.Sin(theta);
            float coeffA = MathF.Sin((1 - t) * theta) / sinTheta;
            float coeffB = MathF.Sin(t * theta) / sinTheta;

            Vector3 result = coeffA * aNorm + coeffB * bNorm;
            float mag = magA + (magB - magA) * t;
            return result * mag;
        }
    }
    
    // Operators
    public partial struct Vector3
    {
        public static implicit operator Vector3(Color color)
        {
            return new Vector3(color.r / 255f, color.g / 255f, color.b / 255f);
        }
        
        public static implicit operator Vector3(Vector2 vector)
        {
            return new(vector.x, vector.y, 0f);
        }
        
        public static implicit operator Vector3(Vector4 vector)
        {
            return new(vector.x, vector.y, vector.z);
        }

        public static Vector3 operator + (Vector3 a, Vector3 b)
        {
            return new(a.x + b.x, a.y + b.y, a.z + b.z);
        }
        
        public static Vector3 operator - (Vector3 a, Vector3 b)
        {
            return new(a.x - b.x, a.y - b.y, a.z - b.z);
        }
        
        public static Vector3 operator - (Vector3 a)
        {
            return new(-a.x, -a.y, -a.z);
        }

        public static Vector3 operator * (Vector3 a, float value)
        {
            return new(a.x * value, a.y * value, a.z * value);
        }
        
        public static Vector3 operator * (float value, Vector3 a)
        {
            return new(a.x * value, a.y * value, a.z * value);
        }

        public static Vector3 operator / (Vector3 a, float d)
        {
            if (MathF.Abs(d) < Epsilon) return Zero;
            
            return new(a.x / d, a.y / d, a.z / d);
        }

        public static bool operator == (Vector3 a, Vector3 b)
        {
            return MathF.Abs(a.x - b.x) <= Epsilon && MathF.Abs(a.y - b.y) <= Epsilon && MathF.Abs(a.z - b.z) <= Epsilon;
        }

        public static bool operator != (Vector3 a, Vector3 b)
        {
            return MathF.Abs(a.x - b.x) > Epsilon || MathF.Abs(a.y - b.y) > Epsilon || MathF.Abs(a.z - b.z) > Epsilon;
        }
        
        public bool Equals(Vector3 other)
        {
            return this == other;
        }

        public override bool Equals(object? obj)
        {
            return obj is Vector3 other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y, z);
        }

        public override string ToString()
        {
            return $"({x:F3}, {y:F3}, {z:F3})";
        }
    }
}