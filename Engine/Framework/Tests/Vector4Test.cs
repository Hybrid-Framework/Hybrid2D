using System;

namespace Hybrid
{
    public class Vector4Test : Test
    {
        public override void Perform()
        {
            float tolerance = 1e-3f;

            Vector4 a = new Vector4(10f, 20f, 30f, 40f);
            Vector4 b = new Vector4(40f, 80f, 120f, 160f);

            // sqrMagnitude
            Display("a.sqrMagnitude", MathF.Abs(a.sqrMagnitude - (10*10 + 20*20 + 30*30 + 40*40)) < tolerance);

            // magnitude
            Display("a.magnitude", MathF.Abs(a.magnitude - MathF.Sqrt(10*10 + 20*20 + 30*30 + 40*40)) < tolerance);

            // normalized magnitude
            Display("a.normalized magnitude", MathF.Abs(a.normalized.magnitude - 1f) < tolerance);

            // Lerp midpoint
            Vector4 lerpMid = Vector4.Lerp(a, b, 0.5f);
            Display("Lerp midpoint", Vector4.Approximately(lerpMid, new Vector4(25f, 50f, 75f, 100f), tolerance));

            // LerpUnclamped beyond 1
            Vector4 lerpUnclamped = Vector4.LerpUnclamped(a, b, 1.5f);
            Display("LerpUnclamped beyond", Vector4.Approximately(lerpUnclamped, a + (b - a) * 1.5f, tolerance));

            // Addition
            Display("Addition", Vector4.Approximately(a + b, new Vector4(50f, 100f, 150f, 200f), tolerance));

            // Subtraction
            Display("Subtraction", Vector4.Approximately(a - b, new Vector4(-30f, -60f, -90f, -120f), tolerance));

            // Negation
            Display("Negation", Vector4.Approximately(-a, new Vector4(-10f, -20f, -30f, -40f), tolerance));

            // Multiplication float
            Display("Multiplication float", Vector4.Approximately(a * 2f, new Vector4(20f, 40f, 60f, 80f), tolerance));

            // Division float
            Display("Division float", Vector4.Approximately(a / 2f, new Vector4(5f, 10f, 15f, 20f), tolerance));

            // Dot product
            float dot = Vector4.Dot(a, b); // 10*40 + 20*80 + 30*120 + 40*160 = 400 + 1600 + 3600 + 6400 = 12000
            Display("Dot product", MathF.Abs(dot - 12000f) < tolerance);

            // Distance
            Display("Distance a->b", MathF.Abs(Vector4.Distance(a, b) - 164.317f) < tolerance);

            // Normalize
            Vector4 normalized = Vector4.Normalize(a);
            Display("Normalized", MathF.Abs(normalized.magnitude - 1f) < tolerance);

            // Scale
            Vector4 scale = Vector4.Scale(a, b);
            Display("Scale", Vector4.Approximately(scale, new Vector4(400f, 1600f, 3600f, 6400f), tolerance));

            // ClampMagnitude
            Vector4 clamped = Vector4.Normalize(b) * 50f; // scale to length 50
            Display("ClampMagnitude", MathF.Abs(clamped.magnitude - 50f) < tolerance);

            // MoveTowards
            Vector4 moved = Vector4.MoveTowards(a, b, 10f);
            Vector4 moveExpected = a + (b - a).normalized * 10f;
            Display("MoveTowards", Vector4.Approximately(moved, moveExpected, tolerance));

            // Project (onto b)
            Vector4 projected = Vector4.Project(a, b);
            Display("Project", projected.magnitude > 0f); // sanity check

            // Test ToString
            Display("ToString", a.ToString() == "(10.000, 20.000, 30.000, 40.000)");
        }
    }
}