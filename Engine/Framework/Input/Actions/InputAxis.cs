using System;

namespace Hybrid
{
    internal class InputAxis
    {
        private readonly Func<float> ValueFunction;
        
        internal InputAxis(Func<float> Value)
        {
            this.ValueFunction = Value;
        }

        public float Value()
        {
            return ValueFunction();
        }

        public bool Negative()
        {
            return Value() < 0;
        }

        public bool Positive()
        {
            return Value() > 0;
        }
    }
}