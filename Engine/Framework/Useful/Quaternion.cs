using System;

namespace Hybrid
{
    // Quaternion
    public partial struct Quaternion : IEquatable<Quaternion>
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public Quaternion(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public Quaternion(Vector3 axis, float degrees)
        {
            float rad = degrees * MathF.PI / 180f;
            float half = rad * 0.5f;
            float sin = MathF.Sin(half);

            axis = axis.normalized;
            x = axis.x * sin;
            y = axis.y * sin;
            z = axis.z * sin;
            w = MathF.Cos(half);
        }
    }

    // Properties
    public partial struct Quaternion
    {
        public static readonly Quaternion Identity = new(0f, 0f, 0f, 1f);
        
        public static float Epsilon = 1e-5f;
    }
    
    // Methods
    public partial struct Quaternion
    {
        public static bool Approximately(Quaternion a, Quaternion b, float tolerance = 1e-5f)
        {
            return MathF.Abs(a.x - b.x) <= tolerance &&
                   MathF.Abs(a.y - b.y) <= tolerance &&
                   MathF.Abs(a.z - b.z) <= tolerance &&
                   MathF.Abs(a.w - b.w) <= tolerance;
        }
    }

    // Operators
    public partial struct Quaternion
    {
        public static Vector3 operator * (Quaternion q, Vector3 v)
        {
            Vector3 u = new(q.x, q.y, q.z);
            Vector3 uv = Vector3.Cross(u, v);
            Vector3 uuv = Vector3.Cross(u, uv);
            uv *= (2f * q.w);
            uuv *= 2f;
            
            return v + uv + uuv;
        }

        public static Quaternion operator * (Quaternion lhs, Quaternion rhs)
        {
            return new Quaternion
            (
                lhs.w * rhs.x + lhs.x * rhs.w + lhs.y * rhs.z - lhs.z * rhs.y,
                lhs.w * rhs.y - lhs.x * rhs.z + lhs.y * rhs.w + lhs.z * rhs.x,
                lhs.w * rhs.z + lhs.x * rhs.y - lhs.y * rhs.x + lhs.z * rhs.w,
                lhs.w * rhs.w - lhs.x * rhs.x - lhs.y * rhs.y - lhs.z * rhs.z
            );
        }

        public static bool operator == (Quaternion a, Quaternion b)
        {
            return Approximately(a, b, Epsilon);
        }

        public static bool operator != (Quaternion a, Quaternion b)
        {
            return !Approximately(a, b, Epsilon);
        }

        public override bool Equals(object? obj)
        {
            return obj is Quaternion other && Equals(other);
        }

        public bool Equals(Quaternion other)
        {
            return this == other;
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
