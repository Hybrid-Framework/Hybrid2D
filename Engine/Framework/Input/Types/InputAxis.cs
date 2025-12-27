using System;

namespace Hybrid
{
    internal class InputAxis
    {
        private float Value = 0f;
        

        internal float GetValue()
        {
            return Value;
        }

        internal void SetValue(float value)
        {
            Value = value;
        }
        
        internal void SetValue(float value, float min, float max)
        {
            Value = Maths.Clamp(value, min, max);
        }

        internal void Reset()
        {
            Value = 0f;
        }
    }
}