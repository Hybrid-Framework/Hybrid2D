using System;

namespace Hybrid
{
    internal class InputAxis
    {
        private float Value = 0f;
        

        internal void SetState(float value)
        {
            Value = value;
        }
        
        internal void SetState(float value, float min, float max)
        {
            Value = Maths.Clamp(value, min, max);
        }
        
        internal float GetState()
        {
            return Value;
        }

        internal void Reset()
        {
            Value = 0f;
        }
    }
}