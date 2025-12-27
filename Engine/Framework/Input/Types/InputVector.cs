using System;

namespace Hybrid
{
    internal class InputVector
    {
        private Vector2 Value = Vector2.Zero;
        

        internal void SetValue(Vector2 value)
        {
            Value = value;
        }
        
        internal void SetValue(float x, float y)
        {
            Value = new Vector2(x, y);
        }
        
        internal void SetValue(Vector2 value, float min, float max)
        {
            Value = new Vector2(Maths.Clamp(value.X, min, max), Maths.Clamp(value.Y, min, max));
        }
        
        internal void SetValue(float x, float y, float min, float max)
        {
            Value = new Vector2(Maths.Clamp(x, min, max), Maths.Clamp(y, min, max));
        }

        internal Vector2 GetValue()
        {
            return Value;
        }

        internal void Reset()
        {
            Value = Vector2.Zero;
        }
    }
}