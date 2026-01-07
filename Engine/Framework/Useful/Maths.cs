using System;

namespace Hybrid
{
    // Properties
    public static class Maths
    {
        public const float Pi = MathF.PI;
        public const float TwoPi = 2f * MathF.PI;
        public const float HalfPi = MathF.PI / 2f;
        public const float Deg2Rad = MathF.PI / 180f;
        public const float Rad2Deg = 180f / MathF.PI;
        
        
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

        public static float Abs(float value)
        {
            return MathF.Abs(value);
        }

        public static float Floor(float value)
        {
            return MathF.Floor(value);
        }

        public static int FloorToInt(float value)
        {
            return (int)MathF.Floor(value);
        }

        public static float Ceil(float value)
        {
            return MathF.Ceiling(value);
        }

        public static int CeilToInt(float value)
        {
            return (int)MathF.Ceiling(value);
        }

        public static float Round(float value)
        {
            return MathF.Round(value);
        }

        public static int RoundToInt(float value)
        {
            return (int)MathF.Round(value);
        }

        public static float Min(float a, float b)
        {
            return MathF.Min(a, b);
        }

        public static float Max(float a, float b)
        {
            return MathF.Max(a, b);
        }

        public static float Clamp(float value, float min, float max)
        {
            return Math.Clamp(value, min, max);
        }

        public static float Sign(float value)
        {
            return MathF.Sign(value);
        }

        public static float Pow(float x, float y)
        {
            return MathF.Pow(x, y);
        }

        public static float Exp(float x)
        {
            return MathF.Exp(x);
        }

        public static float Log(float x)
        {
            return MathF.Log(x);
        }

        public static float Log10(float x)
        {
            return MathF.Log10(x);
        }
        
        public static float DegreesToRadians(float degrees)
        {
            return degrees * Deg2Rad;
        }

        public static float RadiansToDegrees(float radians)
        {
            return radians * Rad2Deg;
        }
        
        public static float Lerp(float a, float b, float t)
        {
            return a + (b - a) * Clamp(t, 0f, 1f);
        }
        
        public static float LerpUnclamped(float a, float b, float t)
        {
            return a + (b - a) * t;
        }
        
        public static bool Approximately(float a, float b, float epsilon = 1e-5f)
        {
            return Abs(a - b) < epsilon;
        }
    }
}