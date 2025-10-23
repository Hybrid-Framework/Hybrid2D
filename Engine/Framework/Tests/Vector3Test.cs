using System;

namespace Hybrid
{
    public class Vector3Test : Test
    {
        public override void Perform()
        {
            float tolerance = 1e-3f;

            Vector3 a = new Vector3(10f, 20f, 30f);
            Vector3 b = new Vector3(40f, 80f, 120f);

            // sqrMagnitude
            Display("a.sqrMagnitude", MathF.Abs(a.sqrMagnitude - (10*10 + 20*20 + 30*30)) < tolerance);

            // magnitude
            Display("a.magnitude", MathF.Abs(a.magnitude - MathF.Sqrt(10*10 + 20*20 + 30*30)) < tolerance);

            // normalized magnitude
            Display("a.normalized magnitude", MathF.Abs(a.normalized.magnitude - 1f) < tolerance);

            // Lerp midpoint
            Vector3 lerpMid = Vector3.Lerp(a, b, 0.5f);
            Display("Lerp midpoint", Vector3.Approximately(lerpMid, new Vector3(25f, 50f, 75f), tolerance));

            // LerpUnclamped beyond 1
            Vector3 lerpUnclamped = Vector3.LerpUnclamped(a, b, 1.5f);
            Display("LerpUnclamped beyond", Vector3.Approximately(lerpUnclamped, a + (b - a) * 1.5f, tolerance));

            // Addition
            Display("Addition", Vector3.Approximately(a + b, new Vector3(50f, 100f, 150f), tolerance));

            // Subtraction
            Display("Subtraction", Vector3.Approximately(a - b, new Vector3(-30f, -60f, -90f), tolerance));

            // Negation
            Display("Negation", Vector3.Approximately(-a, new Vector3(-10f, -20f, -30f), tolerance));

            // Multiplication float
            Display("Multiplication float", Vector3.Approximately(a * 2f, new Vector3(20f, 40f, 60f), tolerance));

            // Division float
            Display("Division float", Vector3.Approximately(a / 2f, new Vector3(5f, 10f, 15f), tolerance));

            // Dot product
            float dot = Vector3.Dot(a, b); // 10*40 + 20*80 + 30*120 = 400 + 1600 + 3600 = 5600
            Display("Dot product", MathF.Abs(dot - 5600f) < tolerance);

            // Distance
            float distance = Vector3.Distance(a, b); // sqrt(30^2 + 60^2 + 90^2) = sqrt(900 + 3600 + 8100) = sqrt(12600) ≈ 112.249
            Display("Distance a->b", MathF.Abs(distance - 112.249f) < tolerance);

            // Cross product
            Vector3 cross = Vector3.Cross(a, b);
            Vector3 crossExpected = new Vector3(
                20f * 120f - 30f * 80f,   // 2400 - 2400 = 0
                30f * 40f - 10f * 120f,   // 1200 - 1200 = 0
                10f * 80f - 20f * 40f     // 800 - 800 = 0
            );
            Display("Cross product", Vector3.Approximately(cross, crossExpected, tolerance));

            // Normalize
            Vector3 normalized = Vector3.Normalize(a);
            Display("Normalized", MathF.Abs(normalized.magnitude - 1f) < tolerance);

            // Scale
            Vector3 scale = Vector3.Scale(a, b);
            Display("Scale", Vector3.Approximately(scale, new Vector3(400f, 1600f, 3600f), tolerance));

            // ClampMagnitude
            Vector3 clamped = Vector3.ClampMagnitude(b, 50f);
            Display("ClampMagnitude", clamped.magnitude <= 50f + tolerance);

            // MoveTowards
            Vector3 moved = Vector3.MoveTowards(a, b, 10f);
            Vector3 moveExpected = a + (b - a).normalized * 10f;
            Display("MoveTowards", Vector3.Approximately(moved, moveExpected, tolerance));

            // Project
            Vector3 normal = new Vector3(0, 1, 0);
            Vector3 projected = Vector3.Project(a, normal); // projection on Y-axis
            Display("Project", Vector3.Approximately(projected, new Vector3(0f, 20f, 0f), tolerance));

            // ProjectOnPlane
            Vector3 projPlane = Vector3.ProjectOnPlane(a, normal); // removes Y component
            Display("ProjectOnPlane", Vector3.Approximately(projPlane, new Vector3(10f, 0f, 30f), tolerance));

            // Reflect
            Vector3 reflected = Vector3.Reflect(a, normal);
            Display("Reflect", Vector3.Approximately(reflected, new Vector3(10f, -20f, 30f), tolerance));

            // Slerp midpoint
            Vector3 slerp = Vector3.Slerp(a, b, 0.5f);
            Display("Slerp midpoint approx", slerp.magnitude > 0f); // rough sanity check

            // SignedAngle around Z axis
            Vector3 axis = new Vector3(0, 0, 1); // Z axis
            float signedAngle = Vector3.SignedAngle(new Vector3(1, 0, 0), new Vector3(0,1,0), axis); // should be 90
            Display("SignedAngle Z axis", MathF.Abs(signedAngle - 90f) <= tolerance);
        }
    }
}