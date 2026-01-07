using System.Collections.Generic;
using System;

namespace Hybrid
{
    public class VirtualAxis : VirtualInput
    {
        private readonly List<Func<float>> ValueFunctions = new List<Func<float>>();
        
        
        internal VirtualAxis(string name)
        {
            this.Name = name;
        }
        
        public void Bind(Func<float> Value)
        {
            if (Value != null)
            {
                ValueFunctions.Add(Value);
            }
        }
        
        public void Unbind(Func<float> Value)
        {
            if (Value != null)
            {
                ValueFunctions.Remove(Value);
            }
        }

        public float Value()
        {
            foreach (var function in ValueFunctions)
            {
                var value = function();
                
                if (value != 0)
                {
                    return value;
                }
            }

            return 0;
        }

        public bool Positive()
        {
            return Value() > 0;
        }
        
        public bool Negative()
        {
            return Value() < 0;
        }
    }
}