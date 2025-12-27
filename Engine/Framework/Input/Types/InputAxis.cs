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
            this.Value = value;
        }
    }
}