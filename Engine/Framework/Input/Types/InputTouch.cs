using System;

namespace Hybrid
{
    internal class InputTouch
    {
        internal InputVector Position { get; private set; } = new InputVector();
        internal InputVector Delta { get; private set; } = new InputVector();
        internal Phase Phase { get; private set; } = Phase.None;
        internal int Index { get; private set; }


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
        }
    }
}