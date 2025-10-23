using System;

namespace Hybrid
{
    public class Vector2Test : Test
    {
        public override void Perform()
        {
            Console.WriteLine("# Vector2 Tests");
            
            float tolerance = 1e-3f;

            // Larger vectors
            Vector2 a = new Vector2(10f, 20f);
            Vector2 b = new Vector2(40f, 80f);

            // sqrMagnitude
            Display("a.sqrMagnitude", MathF.Abs(a.sqrMagnitude - 500f) < tolerance);

            // magnitude
            Display("a.magnitude", MathF.Abs(a.magnitude - MathF.Sqrt(500f)) < tolerance);

            // normalized magnitude
            Display("a.normalized magnitude", MathF.Abs(a.normalized.magnitude - 1f) < tolerance);

            // Lerp midpoint
            Vector2 lerpMid = Vector2.Lerp(a, b, 0.5f);
            Display("Lerp midpoint", Vector2.Approximately(lerpMid, new Vector2(25f, 50f), tolerance));

            // LerpUnclamped beyond 1
            Vector2 lerpUnclamped = Vector2.LerpUnclamped(a, b, 1.5f);
            Display("LerpUnclamped beyond", Vector2.Approximately(lerpUnclamped, a + (b - a) * 1.5f, tolerance));

            // Addition
            Display("Addition", Vector2.Approximately(a + b, new Vector2(50f, 100f), tolerance));

            // Subtraction
            Display("Subtraction", Vector2.Approximately(a - b, new Vector2(-30f, -60f), tolerance));

            // Negation
            Display("Negation", Vector2.Approximately(-a, new Vector2(-10f, -20f), tolerance));

            // Multiplication float
            Display("Multiplication float", Vector2.Approximately(a * 4f, new Vector2(40f, 80f), tolerance));

            // Division float
            Display("Division float", Vector2.Approximately(a / 4f, new Vector2(2.5f, 5f), tolerance));

            // Dot product
            Display("Dot product", Math.Abs(Vector2.Dot(a, b) - 2000) < tolerance);

            // Distance
            Display("Distance a->b", MathF.Abs(Vector2.Distance(a, b) - 67.082039f) < tolerance);

            // Perpendicular
            Display("Perpendicular", Vector2.Approximately(Vector2.Perpendicular(a), new Vector2(-20f, 10f), tolerance));

            // SignedAngle: non-collinear vectors
            Vector2 x = new Vector2(10f, 0f);  // along +x
            Vector2 y = new Vector2(0f, 10f);  // along +y
            Display("SignedAngle", MathF.Abs(Vector2.SignedAngle(x, y) - 90f) < tolerance);

            // Reflection
            Vector2 normal = new Vector2(0f, 1f);
            Display("Reflection", Vector2.Approximately(Vector2.Reflect(a, normal), new Vector2(10f, -20f), tolerance));

            // Scale
            Display("Scale", Vector2.Approximately(Vector2.Scale(a, b), new Vector2(400f, 1600f), tolerance));

            // ClampMagnitude
            Vector2 clamped = Vector2.ClampMagnitude(b, 50f);
            Display("ClampMagnitude", MathF.Abs(clamped.magnitude - 50f) < tolerance);

            // MoveTowards
            Vector2 moved = Vector2.MoveTowards(a, b, 10f);
            Vector2 moveExpected = a + (b - a).normalized * 10f;
            Display("MoveTowards", Vector2.Approximately(moved, moveExpected, tolerance));
        }
    }
}
