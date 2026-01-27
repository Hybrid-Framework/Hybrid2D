using System;

namespace Hybrid
{
    internal class AndroidEvents : IPlatformEvents
    {
        public bool PollEvents(out SDL.Event e)
        {
            return SDL.PollEvent(out e);
        }
    }
}