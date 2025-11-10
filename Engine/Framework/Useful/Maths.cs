using System;

namespace Hybrid
{
    // Maths
    public static partial class Maths
    {
        public const float PI = MathF.PI;
        public const float TwoPI = 2 * MathF.PI;
        public const float HalfPI = MathF.PI / 2f;
        public const float Deg2Rad = MathF.PI / 180f;
        public const float Rad2Deg = 180f / MathF.PI;
        public const float Epsilon = 1e-5f;
    }
    
    // Methods
    public static partial class Maths
    {
        public static float RadiansToDegrees(float radians)
        {
            return radians * Rad2Deg;
        }

        public static float DegreesToRadians(float degrees)
        {
            return degrees * Deg2Rad;
        }

        public static float Sin(float radians)
        {
            return MathF.Sin(radians);
        }

        public static float Cos(float radians)
        {
            return MathF.Cos(radians);
        }

        public static float Tan(float radians)
        {
            return MathF.Tan(radians);
        }

        public static float Asin(float value)
        {
            return MathF.Asin(value);
        }

        public static float Acos(float value)
        {
            return MathF.Acos(value);
        }

        public static float Atan(float value)
        {
            return MathF.Atan(value);
        }

        public static float Atan2(float y, float x)
        {
            return MathF.Atan2(y, x);
        }

        public static float Sqrt(float value)
        {
            return MathF.Sqrt(value);
        }

        public static float Pow(float x, float y)
        {
            return MathF.Pow(x, y);
        }

        public static float Exp(float power)
        {
            return MathF.Exp(power);
        }

        public static float Log(float value)
        {
            return MathF.Log(value);
        }

        public static float Log10(float value)
        {
            return MathF.Log10(value);
        }

        public static float Floor(float value)
        {
            return MathF.Floor(value);
        }

        public static float Ceil(float value)
        {
            return MathF.Ceiling(value);
        }

        public static float Round(float value)
        {
            return MathF.Round(value);
        }

        public static float Clamp(float value, float min, float max)
        {
            return Math.Clamp(value, min, max);
        }

        public static float Min(float a, float b)
        {
            return MathF.Min(a, b);
        }

        public static float Max(float a, float b)
        {
            return MathF.Max(a, b);
        }

        public static float Abs(float value)
        {
            return MathF.Abs(value);
        }

        public static float Lerp(float a, float b, float t)
        {
            return a + (b - a) * Clamp(t, 0f, 1f);
        }
        
        public static float LerpUnclamped(float a, float b, float t)
        {
            return a + (b - a) * t;
        }

        public static bool Approximately(float a, float b)
        {
            return Abs(b - a) < Epsilon;
        }
        
        public static float PingPong(float t, float length)
        {
            t = t % (2 * length);
            
            return length - Abs(t - length);
        }
    }
}