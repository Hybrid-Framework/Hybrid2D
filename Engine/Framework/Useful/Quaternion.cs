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
        public static readonly Quaternion identity = new(0f, 0f, 0f, 1f);
        
        public static float epsilon = 1e-5f;
        
        public Vector3 eulerAngles
        {
            get
            {
                float ysqr = y * y;
                float t0 = +2.0f * (w * x + y * z);
                float t1 = +1.0f - 2.0f * (x * x + ysqr);
                float roll = MathF.Atan2(t0, t1);

                float t2 = +2.0f * (w * y - z * x);
                t2 = Math.Clamp(t2, -1f, 1f);
                float pitch = MathF.Asin(t2);

                float t3 = +2.0f * (w * z + x * y);
                float t4 = +1.0f - 2.0f * (ysqr + z * z);
                float yaw = MathF.Atan2(t3, t4);

                return new Vector3
                (
                    roll * (180f / MathF.PI),
                    pitch * (180f / MathF.PI),
                    yaw * (180f / MathF.PI)
                );
            }
            set
            {
                Quaternion q = Euler(value);
                this = q;
            }
        }
        
        public Quaternion normalized
        {
            get
            {
                float mag = MathF.Sqrt(x*x + y*y + z*z + w*w);
                
                if (mag > epsilon)
                {
                    return new Quaternion(x / mag, y / mag, z / mag, w / mag);
                }
                
                return identity;
            }
        }
    }
    
    // Methods
    public partial struct Quaternion
    {
        public void Set(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        
        public void Set(Vector3 vector, float degrees)
        {
            x = vector.x;
            y = vector.y;
            z = vector.z;
            w = degrees;
        }
        
        public void Normalize()
        {
            float mag = MathF.Sqrt(x*x + y*y + z*z + w*w);
            
            if (mag > epsilon)
            {
                x /= mag;
                y /= mag;
                z /= mag;
                w /= mag;
            }
            else
            {
                x = y = z = 0f;
                w = 1f;
            }
        }
        
        public static float Angle(Quaternion a, Quaternion b)
        {
            return MathF.Acos(MathF.Min(MathF.Abs(Dot(a, b)), 1f)) * 2f * (180f / MathF.PI);
        }

        public static Quaternion AngleAxis(float angle, Vector3 axis)
        {
            return new Quaternion(axis, angle);
        }

        public static float Dot(Quaternion a, Quaternion b)
        {
            return a.x*b.x + a.y*b.y + a.z*b.z + a.w*b.w;
        }

        public static Quaternion Euler(float x, float y, float z)
        {
            return Euler(new Vector3(x, y, z));
        }

        public static Quaternion Euler(Vector3 euler)
        {
            float cx = MathF.Cos(euler.x * 0.5f * MathF.PI / 180f);
            float sx = MathF.Sin(euler.x * 0.5f * MathF.PI / 180f);
            float cy = MathF.Cos(euler.y * 0.5f * MathF.PI / 180f);
            float sy = MathF.Sin(euler.y * 0.5f * MathF.PI / 180f);
            float cz = MathF.Cos(euler.z * 0.5f * MathF.PI / 180f);
            float sz = MathF.Sin(euler.z * 0.5f * MathF.PI / 180f);

            return new Quaternion
            (
                sx * cy * cz - cx * sy * sz,
                cx * sy * cz + sx * cy * sz,
                cx * cy * sz - sx * sy * cz,
                cx * cy * cz + sx * sy * sz
            );
        }

        public static Quaternion FromToRotation(Vector3 from, Vector3 to)
        {
            Vector3 f = from.normalized;
            Vector3 t = to.normalized;
            Vector3 axis;
            
            float cosTheta = Vector3.Dot(f, t);

            if (cosTheta >= 1.0f - epsilon)
            {
                return identity;
            }

            if (cosTheta <= -1.0f + epsilon)
            {
                axis = Vector3.Cross(new Vector3(1,0,0), f);
                
                if (axis.sqrMagnitude < epsilon)
                {
                    axis = Vector3.Cross(new Vector3(0, 1, 0), f);
                }
                
                axis.Normalize();
                return AngleAxis(180f, axis);
            }

            axis = Vector3.Cross(f, t);
            float s = MathF.Sqrt((1 + cosTheta) * 2);
            float invs = 1 / s;

            return new Quaternion
            (
                axis.x * invs,
                axis.y * invs,
                axis.z * invs,
                s * 0.5f
            );
        }

        public static Quaternion Inverse(Quaternion quaternion)
        {
            var q = quaternion;
            float norm = q.x * q.x + q.y * q.y + q.z * q.z + q.w * q.w;
            
            if (norm > epsilon)
            {
                float inverse = 1f / norm;
                return new Quaternion(-q.x * inverse, -q.y * inverse, -q.z * inverse, q.w * inverse);
            }
            
            return identity;
        }

        public static Quaternion Lerp(Quaternion a, Quaternion b, float t)
        {
            t = Math.Clamp(t, 0f, 1f);
            
            return LerpUnclamped(a, b, t);
        }

        public static Quaternion LerpUnclamped(Quaternion a, Quaternion b, float t)
        {
            Quaternion result = new Quaternion
            (
                a.x + (b.x - a.x) * t,
                a.y + (b.y - a.y) * t,
                a.z + (b.z - a.z) * t,
                a.w + (b.w - a.w) * t
            );
            
            return result.normalized;
        }

        public static Quaternion LookRotation(Vector3 forward, Vector3 up)
        {
            forward = forward.normalized;
            Vector3 right = Vector3.Cross(up, forward).normalized;
            up = Vector3.Cross(forward, right);

            float m00 = right.x, m01 = right.y, m02 = right.z;
            float m10 = up.x, m11 = up.y, m12 = up.z;
            float m20 = forward.x, m21 = forward.y, m22 = forward.z;

            float trace = m00 + m11 + m22;
            Quaternion q = identity;

            if (trace > 0)
            {
                float s = MathF.Sqrt(trace + 1.0f) * 2;
                q.w = 0.25f * s;
                q.x = (m21 - m12) / s;
                q.y = (m02 - m20) / s;
                q.z = (m10 - m01) / s;
            }
            else if ((m00 > m11) && (m00 > m22))
            {
                float s = MathF.Sqrt(1.0f + m00 - m11 - m22) * 2;
                q.w = (m21 - m12) / s;
                q.x = 0.25f * s;
                q.y = (m01 + m10) / s;
                q.z = (m02 + m20) / s;
            }
            else if (m11 > m22)
            {
                float s = MathF.Sqrt(1.0f + m11 - m00 - m22) * 2;
                q.w = (m02 - m20) / s;
                q.x = (m01 + m10) / s;
                q.y = 0.25f * s;
                q.z = (m12 + m21) / s;
            }
            else
            {
                float s = MathF.Sqrt(1.0f + m22 - m00 - m11) * 2;
                q.w = (m10 - m01) / s;
                q.x = (m02 + m20) / s;
                q.y = (m12 + m21) / s;
                q.z = 0.25f * s;
            }

            return q.normalized;
        }

        public static Quaternion RotateTowards(Quaternion from, Quaternion to, float maxDegreesDelta)
        {
            float angle = Angle(from, to);
            
            if (angle < epsilon)
            {
                return to;
            }

            float t = MathF.Min(1f, maxDegreesDelta / angle);
            return SlerpUnclamped(from, to, t);
        }

        public static Quaternion Slerp(Quaternion a, Quaternion b, float t)
        {
            t = Math.Clamp(t, 0f, 1f);
            
            return SlerpUnclamped(a, b, t);
        }

        public static Quaternion SlerpUnclamped(Quaternion a, Quaternion b, float t)
        {
            float dot = Dot(a.normalized, b.normalized);
            dot = Math.Clamp(dot, -1f, 1f);

            float theta = MathF.Acos(dot);
            
            if (theta < epsilon)
            {
                return b.normalized;
            }

            float sinTheta = MathF.Sin(theta);
            float coeffA = MathF.Sin((1f - t) * theta) / sinTheta;
            float coeffB = MathF.Sin(t * theta) / sinTheta;

            Quaternion result = new Quaternion
            (
                coeffA * a.x + coeffB * b.x,
                coeffA * a.y + coeffB * b.y,
                coeffA * a.z + coeffB * b.z,
                coeffA * a.w + coeffB * b.w
            );
            
            return result.normalized;
        }
        
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
        public static Vector3 operator * (Quaternion quaternion, Vector3 vector)
        {
            Vector3 u = new(quaternion.x, quaternion.y, quaternion.z);
            Vector3 uv = Vector3.Cross(u, vector);
            Vector3 uuv = Vector3.Cross(u, uv);
            uv *= (2f * quaternion.w);
            uuv *= 2f;
            
            return vector + uv + uuv;
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
            return Approximately(a, b, epsilon);
        }

        public static bool operator != (Quaternion a, Quaternion b)
        {
            return !Approximately(a, b, epsilon);
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
