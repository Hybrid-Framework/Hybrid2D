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

        internal void Reset()
        {
            switch (State)
            {
                case InputState.Press | InputState.Down:
                {
                    State = InputState.Down;
                    break;
                }
                    
                case InputState.Release:
                {
                    State = InputState.None;
                    break;
                }
            }
        }
        
        internal bool IsDown()
        {
            return State.HasFlag(InputState.Down);
        }

        internal bool IsPressed()
        {
            return State.HasFlag(InputState.Press);
        }
        
        internal bool IsReleased()
        {
            return State.HasFlag(InputState.Release);
        }
    }
}