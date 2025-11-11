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

    // Methods
    public partial struct Vector3
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
                return (X * X + Y * Y + Z * Z);
            }
        }

        public Vector3 Normalized
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
        
        public static float Angle(Vector3 from, Vector3 to)
        {
            float denominator = Maths.Sqrt(from.SqrMagnitude * to.SqrMagnitude);

            if (denominator < Maths.Epsilon)
            {
                return 0f;
            }

            float dot = Maths.Clamp(Dot(from, to) / denominator, -1f, 1f);
            return Maths.Acos(dot) * Maths.Rad2Deg;
        }

        public static Vector3 ClampMagnitude(Vector3 vector, float maxLength)
        {
            float sqrMag = vector.SqrMagnitude;
            
            if (sqrMag > maxLength * maxLength)
            {
                float mag = Maths.Sqrt(sqrMag);
                return vector / mag * maxLength;
            }
            
            return vector;
        }

        public static Vector3 Cross(Vector3 a, Vector3 b)
        {
            return new Vector3
            (
                a.Y * b.Z - a.Z * b.Y,
                a.Z * b.X - a.X * b.Z,
                a.X * b.Y - a.Y * b.X
            );
        }

        public static float Distance(Vector3 a, Vector3 b)
        {
            return (a - b).Magnitude;
        }

        public static float Dot(Vector3 a, Vector3 b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }

        public static Vector3 Lerp(Vector3 a, Vector3 b, float t)
        {
            return new Vector3
            (
                Maths.Lerp(a.X, b.X, t),
                Maths.Lerp(a.Y, b.Y, t),
                Maths.Lerp(a.Z, b.Z, t)
            );
        }

        public static Vector3 LerpUnclamped(Vector3 a, Vector3 b, float t)
        {
            return new Vector3
            (
                Maths.LerpUnclamped(a.X, b.X, t),
                Maths.LerpUnclamped(a.Y, b.Y, t),
                Maths.LerpUnclamped(a.Z, b.Z, t)
            );
        }

        public static Vector3 Max(Vector3 a, Vector3 b)
        {
            return new Vector3
            (
                Maths.Max(a.X, b.X),
                Maths.Max(a.Y, b.Y),
                Maths.Max(a.Z, b.Z)
            );
        }

        public static Vector3 Min(Vector3 a, Vector3 b)
        {
            return new Vector3
            (
                Maths.Min(a.X, b.X),
                Maths.Min(a.Y, b.Y),
                Maths.Min(a.Z, b.Z)
            );
        }

        public static Vector3 MoveTowards(Vector3 current, Vector3 target, float maxDistanceDelta)
        {
            Vector3 delta = target - current;
            float distance = delta.SqrMagnitude;

            if (distance == 0f || (maxDistanceDelta >= 0f && distance <= maxDistanceDelta * maxDistanceDelta))
            {
                return target;
            }

            float dist = Maths.Sqrt(distance);
            return current + delta / dist * maxDistanceDelta;
        }

        public static Vector3 Reflect(Vector3 direction, Vector3 normal)
        {
            return direction - 2f * Dot(direction, normal) * normal;
        }

        public static float SignedAngle(Vector3 from, Vector3 to, Vector3 axis)
        {
            return Angle(from, to) * Maths.Sign(Dot(axis, Cross(from, to)));;
        }
        
        public void Normalize()
        {
            float mag = Magnitude;
            
            if (mag > Maths.Epsilon)
            {
                this.X /= mag;
                this.Y /= mag;
                this.Z /= mag;
            }
            else
            {
                this.X = 0;
                this.Y = 0;
                this.Z = 0;
            }
        }

        public void Set(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
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