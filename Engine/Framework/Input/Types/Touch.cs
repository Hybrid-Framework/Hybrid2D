using System;

namespace Hybrid
{
    public class Touch
    {
        internal Vector2 PositionDelta = Vector2.Zero;
        internal Vector2 Position = Vector2.Zero;
        internal Phase Phase = Phase.None;
        internal readonly int Finger;
        
        
        internal Touch(int finger)
        {
            this.Finger = finger;
        }
        
        internal void Reset()
        {
            PositionDelta = Vector2.Zero;

            if (Phase == Phase.Ended || Phase == Phase.Canceled)
            {
                Position = Vector2.Zero;
                Phase = Phase.None;
            }

            if (Phase == Phase.Began)
            {
                Phase = Phase.Stationary;
            }

            if (Phase == Phase.Moved)
            {
                Phase = Phase.Stationary;
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

        public int GetFinger()
        {
            return Finger;
        }

        public Phase GetPhase()
        {
            return Phase;
        }
    }
}