using System.Collections.Generic;
using System;

namespace Hybrid
{
    public class InputVector : InputAction
    {
        private readonly List<Func<Vector2>> ValueFunctions = new List<Func<Vector2>>();
        
        
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

        public bool Up()
        {
            return Value().Y > 0;
        }
        
        public bool Down()
        {
            return Value().Y < 0;
        }
        
        public bool Left()
        {
            return Value().X < 0;
        }
        
        public bool Right()
        {
            return Value().X > 0;
        }
    }
}