using System;

namespace Hybrid
{
    public class Touch
    {
        internal InputVector Position { get; private set; } = new InputVector();
        internal InputVector Delta { get; private set; } = new InputVector();
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
            Delta.Reset();

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

        public Vector2 GetPosition()
        {
            return Position.GetState();
        }

        public Vector2 GetDelta()
        {
            return Delta.GetState();
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