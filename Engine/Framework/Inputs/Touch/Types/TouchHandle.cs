using System;

namespace Hybrid
{
    internal class TouchHandle
    {
        internal Point PositionDelta = Point.Zero;
        internal Point Position = Point.Zero;
        internal State State = State.None;
        internal float Pressure;
        
        
        internal void Reset()
        {
            PositionDelta = Point.Zero;

            if (GetTouchDown())
            {
                State = State.Press;
            }

            if (GetTouchUp())
            {
                State = State.None;
                
                PositionDelta = Point.Zero;
                Position = Point.Zero;
                Pressure = 0f;
            }
        }

        internal bool GetTouch()
        {
            return (State & State.Press) != 0;
        }
        
        internal bool GetTouchUp()
        {
            return (State & State.Release) != 0;
        }
        
        internal bool GetTouchDown()
        {
            return (State & State.Down) != 0;
        }
        
        internal Point GetPositionDelta()
        {
            return PositionDelta;
        }

        internal Point GetPosition()
        {
            return Position;
        }

        internal float GetPressure()
        {
            return Pressure;
        }
    }
}