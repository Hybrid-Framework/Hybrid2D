using System;

namespace Hybrid
{
    public sealed class WaitForSeconds : YieldInstruction
    {
        internal float Remaining { get; set; }

        public WaitForSeconds(float seconds)
        {
            Remaining = seconds;
        }
    }
}