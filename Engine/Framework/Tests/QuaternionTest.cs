using System;

namespace Hybrid
{
    public class QuaternionTest : Test
    {
        public override void Perform()
        {
            Console.WriteLine("# Quaternion Tests");
            
            float tolerance = 1e-3f;

            // Test quaternions
            Quaternion q1 = Quaternion.Euler(30f, 45f, 60f);
            Quaternion q2 = Quaternion.Euler(-45f, 90f, 0f);
            Vector3 v = new Vector3(1f, 0f, 0f);

            // Normalized check
            Quaternion qNorm = q1.normalized;
            float lenSq = qNorm.x*qNorm.x + qNorm.y*qNorm.y + qNorm.z*qNorm.z + qNorm.w*qNorm.w;
            Display("Normalized quaternion length", MathF.Abs(lenSq - 1f) < tolerance);

            // Euler round-trip
            Quaternion qFromEuler = Quaternion.Euler(q1.eulerAngles);
            Display("Euler round-trip", Quaternion.Approximately(q1.normalized, qFromEuler.normalized, tolerance));

            // Inverse correctness: q * q⁻¹ = identity
            Quaternion inv = Quaternion.Inverse(q1);
            Quaternion identityCheck = q1 * inv;
            Display("Inverse correctness",
                MathF.Abs(identityCheck.x) < tolerance &&
                MathF.Abs(identityCheck.y) < tolerance &&
                MathF.Abs(identityCheck.z) < tolerance &&
                MathF.Abs(identityCheck.w - 1f) < tolerance);

            // Angle between quaternions
            float angle = Quaternion.Angle(q1, q2);
            Display("Angle between q1 and q2", angle >= 0f && angle <= 180f);

            // Lerp and Slerp produce normalized quaternions
            Quaternion lerp = Quaternion.Lerp(q1, q2, 0.5f);
            float lenLerpSq = lerp.x*lerp.x + lerp.y*lerp.y + lerp.z*lerp.z + lerp.w*lerp.w;
            Display("Lerp normalized", MathF.Abs(lenLerpSq - 1f) < tolerance);

            Quaternion slerp = Quaternion.Slerp(q1, q2, 0.5f);
            float lenSlerpSq = slerp.x*slerp.x + slerp.y*slerp.y + slerp.z*slerp.z + slerp.w*slerp.w;
            Display("Slerp normalized", MathF.Abs(lenSlerpSq - 1f) < tolerance);

            // Rotate a vector
            Vector3 vRotated = q1 * v;
            Display("Vector rotated non-zero", vRotated.sqrMagnitude > 0f);

            // RotateTowards test
            Quaternion rotated = Quaternion.RotateTowards(q1, q2, 10f);
            float rotatedLenSq = rotated.x*rotated.x + rotated.y*rotated.y + rotated.z*rotated.z + rotated.w*rotated.w;
            Display("RotateTowards normalized", MathF.Abs(rotatedLenSq - 1f) < tolerance);

            // AngleAxis
            Quaternion angleAxis = Quaternion.AngleAxis(90f, Vector3.up);
            Display("AngleAxis normalized",
                MathF.Abs(angleAxis.x*angleAxis.x + angleAxis.y*angleAxis.y + angleAxis.z*angleAxis.z + angleAxis.w*angleAxis.w - 1f) < tolerance);

            // LookRotation
            Vector3 forward = new Vector3(0, 0, 1);
            Quaternion look = Quaternion.LookRotation(forward, Vector3.up);
            float lookLenSq = look.x*look.x + look.y*look.y + look.z*look.z + look.w*look.w;
            Display("LookRotation normalized", MathF.Abs(lookLenSq - 1f) < tolerance);
        }
    }
}