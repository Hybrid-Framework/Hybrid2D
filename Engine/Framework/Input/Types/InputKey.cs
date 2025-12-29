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
            if (Down())
            {
                State = State.Hold;
            }

            if (Released())
            {
                State = State.None;
            }
        }
        
        internal bool Down()
        {
            return (State & State.Down) != 0;
        }

        internal bool Held()
        {
            return (State & State.Hold) != 0;
        }
        
        internal bool Released()
        {
            return (State & State.Release) != 0;
        }
    }
}