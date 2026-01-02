using System;

namespace Hybrid
{
    public class Touch
    {
        internal Vector2 PositionDelta = Vector2.Zero;
        internal Vector2 Position = Vector2.Zero;
        internal TouchPhase TouchPhase = TouchPhase.None;
        internal readonly int Finger;
        internal float Pressure;
        
        
        internal Touch(int finger)
        {
            this.Finger = finger;
        }
        
        internal void Reset()
        {
            PositionDelta = Vector2.Zero;

            if (TouchPhase == TouchPhase.Ended || TouchPhase == TouchPhase.Canceled)
            {
                Position = Vector2.Zero;
                TouchPhase = TouchPhase.None;
            }

            if (TouchPhase == TouchPhase.Began)
            {
                TouchPhase = TouchPhase.Stationary;
            }

            if (TouchPhase == TouchPhase.Moved)
            {
                TouchPhase = TouchPhase.Stationary;
            }
        }
        
        public Vector2 GetPositionDelta()
        {
            return PositionDelta;
        }

        public Vector2 GetPosition()
        {
            return Position;
        }

        public float GetPressure()
        {
            return Pressure;
        }

        public int GetFinger()
        {
            return Finger;
        }

        public TouchPhase GetPhase()
        {
            return TouchPhase;
        }
    }
}