using System;

namespace Hybrid
{
    public class Touch
    {
        internal InputVector PositionDelta { get; private set; } = new InputVector();
        internal InputVector Position { get; private set; } = new InputVector();
        internal Phase Phase { get; private set; }
        internal int Finger { get; private set; }
        
        
        internal Touch(int finger)
        {
            this.Finger = finger;
        }
        
        internal void SetState(Phase phase)
        {
            Phase = phase;
        }

        internal Phase GetState()
        {
            return Phase;
        }
        
        internal void Reset()
        {
            PositionDelta.Reset();

            if (Phase == Phase.Ended || Phase == Phase.Canceled)
            {
                Phase = Phase.None;
                Position.Reset();
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
        
        public Vector2 TouchPositionDelta()
        {
            return PositionDelta.GetState();
        }

        public Vector2 TouchPosition()
        {
            return Position.GetState();
        }

        public int TouchFinger()
        {
            return Finger;
        }

        public Phase TouchPhase()
        {
            return Phase;
        }
    }
}