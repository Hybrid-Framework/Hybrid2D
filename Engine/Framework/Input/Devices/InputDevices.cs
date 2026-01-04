using System;

namespace Hybrid
{
    internal abstract class InputDevices
    {
        internal virtual void OnEvent(SDL.Event e) { }
        internal virtual void OnDispose() { }
        internal virtual void OnReset() { }
    }
}