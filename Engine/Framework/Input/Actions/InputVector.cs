using System.Collections.Generic;
using System;

namespace Hybrid
{
    public class InputVector
    {
        private readonly List<Func<Vector2>> ValueFunctions = new List<Func<Vector2>>();
        private string Name { get; set; }
        
        
        internal InputVector(string name)
        {
            this.Name = name;
        }
        
        public void Add(Func<Vector2> Value)
        {
            if (Value != null)
            {
                ValueFunctions.Add(Value);
            }
        }
        
        public void Remove(Func<Vector2> Value)
        {
            if (Value != null)
            {
                ValueFunctions.Remove(Value);
            }
        }

        public Vector2 Value()
        {
            foreach (var function in ValueFunctions)
            {
                var value = function();
                
                if (value.X != 0 || value.Y != 0)
                {
                    return value;
                }
            }

            return Vector2.Zero;
        }
        
        public bool NegativeY()
        {
            return Value().Y < 0;
        }

        public bool PositiveY()
        {
            return Value().Y > 0;
        }

        public bool NegativeX()
        {
            return Value().X < 0;
        }

        public bool PositiveX()
        {
            return Value().X > 0;
        }
        
        public float X()
        {
            return Value().X;
        }
        
        public float Y()
        {
            return Value().Y;
        }
    }
}