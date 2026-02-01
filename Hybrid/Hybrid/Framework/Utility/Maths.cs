using System;

namespace Hybrid
{
    // Values
    public static partial class Maths
    {
        // PI value
        public static float Pi()
        {
            return MathF.PI;
        }

        // 2 PI value
        public static float TwoPi()
        {
            return 2f * MathF.PI;
        }

        // Half of PI value
        public static float HalfPi()
        {
            return MathF.PI / 2f;
        }

        // Degrees to radians value
        public static float Deg2Rad()
        {
            return MathF.PI / 180f;
        }

        // Radians to degrees value
        public static float Rad2Deg()
        {
            return 180f / MathF.PI;
        }
    }
    
    // Functions
    public static partial class Maths
    {
        // Sine of angle in radians
        public static float Sin(float radians)
        {
            return MathF.Sin(radians);
        }

        // Cosine of angle in radians
        public static float Cos(float radians)
        {
            return MathF.Cos(radians);
        }

        // Tangent of angle in radians
        public static float Tan(float radians)
        {
            return MathF.Tan(radians);
        }

        // Arcsine (inverse sine) of value
        public static float Asin(float value)
        {
            return MathF.Asin(value);
        }

        // Arccosine (inverse cosine) of value
        public static float Acos(float value)
        {
            return MathF.Acos(value);
        }

        // Arctangent (inverse tangent) of value
        public static float Atan(float value)
        {
            return MathF.Atan(value);
        }

        // Arctangent of y/x considering quadrant
        public static float Atan2(float y, float x)
        {
            return MathF.Atan2(y, x);
        }

        // Square root
        public static float Sqrt(float value)
        {
            return MathF.Sqrt(value);
        }

        // Absolute value
        public static float Abs(float value)
        {
            return MathF.Abs(value);
        }

        // Round down to nearest integer (float)
        public static float Floor(float value)
        {
            return MathF.Floor(value);
        }

        // Round down to nearest integer (int)
        public static int FloorToInt(float value)
        {
            return (int)MathF.Floor(value);
        }

        // Round up to nearest integer (float)
        public static float Ceil(float value)
        {
            return MathF.Ceiling(value);
        }

        // Round up to nearest integer (int)
        public static int CeilToInt(float value)
        {
            return (int)MathF.Ceiling(value);
        }

        // Round to nearest integer (float)
        public static float Round(float value)
        {
            return MathF.Round(value);
        }

        // Round to nearest integer (int)
        public static int RoundToInt(float value)
        {
            return (int)MathF.Round(value);
        }

        // Return smaller of a and b
        public static float Min(float a, float b)
        {
            return MathF.Min(a, b);
        }

        // Return larger of a and b
        public static float Max(float a, float b)
        {
            return MathF.Max(a, b);
        }
        
        // Clamp value between 0 and 1
        public static float Clamp01(float value)
        {
            return Math.Clamp(value, 0, 1);
        }

        // Clamp value between min and max
        public static float Clamp(float value, float min, float max)
        {
            return Math.Clamp(value, min, max);
        }

        // Sign of value
        public static float Sign(float value)
        {
            return MathF.Sign(value);
        }

        // Raise x to power y
        public static float Pow(float x, float y)
        {
            return MathF.Pow(x, y);
        }

        // Exponential of x
        public static float Exp(float x)
        {
            return MathF.Exp(x);
        }

        // Natural logarithm (ln)
        public static float Log(float x)
        {
            return MathF.Log(x);
        }

        // Base-10 logarithm
        public static float Log10(float x)
        {
            return MathF.Log10(x);
        }
        
        // Is value is a power of 2
        public static bool IsPowerOfTwo(int value)
        {
            return value > 0 && (value & (value - 1)) == 0;
        }
        
        // Loop value t between 0 and length
        public static float Repeat(float t, float length)
        {
            return t - Floor(t / length) * length;
        }

        // Oscillates t between min and max
        public static float PingPong(float t, float min, float max)
        {
            float length = max - min;

            if (length <= 0f)
            {
                return min;
            }

            t = Repeat(t, length * 2f);

            return min + length - Maths.Abs(t - length);
        }

        // Convert degrees to radians
        public static float DegreesToRadians(float degrees)
        {
            return degrees * Deg2Rad();
        }

        // Convert radians to degrees
        public static float RadiansToDegrees(float radians)
        {
            return radians * Rad2Deg();
        }
        
        // Linear interpolation (clamped 0-1)
        public static float Lerp(float a, float b, float t)
        {
            return a + (b - a) * Clamp(t, 0f, 1f);
        }
        
        // Linear interpolation without clamping
        public static float LerpUnclamped(float a, float b, float t)
        {
            return a + (b - a) * t;
        }
        
        // Is a & b approximately the same using epsilon range
        public static bool Approximately(float a, float b, float epsilon = 1e-5f)
        {
            return Abs(a - b) < epsilon;
        }
    }
    
    // Random
    public static partial class Maths
    {
        private static System.Random Rng = new System.Random();
        private static int Seed;

        // Set the random seed
        public static void SetRandomSeed(int seed)
        {
            Seed = seed;
            {
                Rng = new System.Random(seed);
            }
        }

        // Get the random seed
        public static int GetRandomSeed()
        {
            return Seed;
        }

        // Get random value between min and max with seed
        public static float GetRandomValue(float min, float max)
        {
            if (min > max)
            {
                (min, max) = (max, min);
            }

            return min + (max - min) * (float)Rng.NextDouble();
        }
    }
}