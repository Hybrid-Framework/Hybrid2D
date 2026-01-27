using System;

namespace Hybrid
{
    internal interface IPlatformEvents
    {
        bool PollEvents(out SDL.Event e);
    }
}