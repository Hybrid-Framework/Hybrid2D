using System;

namespace Hybrid
{
    internal class InputKey
    {
        private State State = State.None;
        
        
        internal void SetState(State state)
        {
            this.State = state;
        }

        internal State GetState()
        {
            return State;
        }

        internal void Reset()
        {
            switch (State)
            {
                case State.Press | State.Down:
                {
                    State = State.Down;
                    break;
                }
                    
                case State.Release:
                {
                    State = State.None;
                    break;
                }
            }
        }
        
        internal bool IsDown()
        {
            return State.HasFlag(State.Down);
        }

        internal bool IsPressed()
        {
            return State.HasFlag(State.Press);
        }
        
        internal bool IsReleased()
        {
            return State.HasFlag(State.Release);
        }
    }
}