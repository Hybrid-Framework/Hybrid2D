using System;

namespace Hybrid
{
    internal class InputKey
    {
        private InputState State = InputState.None;
        
        
        internal void SetState(InputState state)
        {
            this.State = state;
        }

        internal InputState GetState()
        {
            return State;
        }

        internal bool Press()
        {
            return State.HasFlag(InputState.Press);
        }
        
        internal bool Down()
        {
            return State.HasFlag(InputState.Down);
        }
        
        internal bool Release()
        {
            return State.HasFlag(InputState.Release);
        }
    }
}