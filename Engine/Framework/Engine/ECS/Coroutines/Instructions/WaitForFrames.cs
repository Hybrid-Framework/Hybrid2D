using System;

namespace Hybrid
{
    public sealed class WaitForFrames : YieldInstruction
    {
        internal int Remaining { get; set; }

        public WaitForFrames(int frames)
        {
            Remaining = frames;
        }
    }
}