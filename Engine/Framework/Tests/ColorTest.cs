using System;

namespace Hybrid
{
    public class ColorTest : Test
    {
        public override void Perform()
        {
            Console.WriteLine("# Color Tests");
            
            int tol = 2;

            Color black = Color.black;
            Color white = Color.white;
            Color cornflower = Color.cornflowerBlue;
            Color grayTest = new Color(50, 100, 150, 255);

            // Predefined colors
            Display("Black predefined", black == new Color(0, 0, 0, 255));
            Display("White predefined", white == new Color(255, 255, 255, 255));
            Display("CornflowerBlue predefined", cornflower == new Color(100, 149, 237, 255));

            // Grayscale
            float grayValue = grayTest.grayscale;
            Display("Grayscale approx 0.365", MathF.Abs(grayValue - 0.365f) < 0.01f);

            // Linear -> Gamma roundtrip
            Color linear = grayTest.linear;
            Color gammaBack = linear.gamma;
            Display("Linear -> Gamma roundtrip approx original", Color.Approximately(grayTest, gammaBack, tol));

            // HSV roundtrip
            Color.RGBToHSV(grayTest, out float h, out float s, out float v);
            Color fromHSV = Color.HSVToRGB(h, s, v, grayTest.a);
            Display("HSV roundtrip approx", Color.Approximately(grayTest, fromHSV, tol));

            // Lerp
            Color mid = Color.Lerp(black, white, 0.5f);
            Display("Lerp midpoint == gray", mid == Color.gray);

            // Operators
            Display("Red + Green == Yellow", (Color.red + Color.green) == Color.yellow);
            Display("Yellow - Red == Green", (Color.yellow - Color.red) == new Color(0, 255, 0, 0));
            Display("Cyan * Magenta approx Blue", Color.Approximately(Color.cyan * Color.magenta, Color.blue, tol));
            Display("White / 2 == (128,128,128,128)", (Color.white / 2) == new Color(128, 128, 128, 128));

            // Equality / Inequality
            Display("Equality operator", Color.red == Color.red);
            Display("Inequality operator", Color.red != Color.blue);

            // Vector conversions
            Vector2 v2 = new Vector2(0.1f, 0.2f);
            Display("Vector2 -> Color", ((Color)v2) == new Color(26, 51, 0, 255));

            Vector3 v3 = new Vector3(0.1f, 0.2f, 0.3f);
            Display("Vector3 -> Color", ((Color)v3) == new Color(26, 51, 77, 255));

            Vector4 v4 = new Vector4(0.1f, 0.2f, 0.3f, 0.4f);
            Display("Vector4 -> Color", ((Color)v4) == new Color(26, 51, 77, 102));

            // LerpUnclamped test
            Color unclamped = Color.LerpUnclamped(Color.red, Color.blue, 1.5f);
            Display("LerpUnclamped beyond 1", unclamped == Color.blue);

            // Approximately test
            Color slightlyOff = new Color(101, 150, 238, 255);
            Display("Approximately with tolerance", Color.Approximately(cornflower, slightlyOff, tol));
        }
    }
}