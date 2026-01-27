using System;

namespace Hybrid
{
    internal class LinuxEvents : IPlatformEvents
    {
        public bool PollEvents(out SDL.Event e)
        {
            return SDL.PollEvent(out e);
        }
    }
}