using System;

namespace Hybrid
{
    internal class InputVector
    {
        private Vector2 Value = Vector2.Zero;
        

        internal void SetValue(Vector2 vector)
        {
            this.Value = vector;
        }

        internal Vector2 GetValue()
        {
            return Value;
        }
    }
}