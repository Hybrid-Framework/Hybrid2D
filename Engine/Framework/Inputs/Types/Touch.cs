using System;

namespace Hybrid
{
    public class Touch
    {
        internal TouchPhase TouchPhase = TouchPhase.None;
        internal Point PositionDelta = Point.Zero;
        internal Point Position = Point.Zero;
        internal readonly int Finger;
        internal float Pressure;
        
        
        internal Touch(int finger)
        {
            this.Finger = finger;
        }
        
        internal void Reset()
        {
            PositionDelta = Point.Zero;

            if (TouchPhase == TouchPhase.Ended || TouchPhase == TouchPhase.Canceled)
            {
                Position = Point.Zero;
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
        
        public Point GetPositionDelta()
        {
            return PositionDelta;
        }

        public Point GetPosition()
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