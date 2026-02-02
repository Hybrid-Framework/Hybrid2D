using System;

namespace Hybrid
{
    internal class TouchHandle
    {
        internal Point PositionDelta = new Point();
        internal Point Position = new Point();
        internal State State = State.None;
        internal float Pressure;
        
        
        internal void Reset()
        {
            PositionDelta = new Point();

            if (GetTouchDown())
            {
                State = State.Press;
            }

            if (GetTouchUp())
            {
                State = State.None;
                
                PositionDelta = new Point();
                Position = new Point();
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