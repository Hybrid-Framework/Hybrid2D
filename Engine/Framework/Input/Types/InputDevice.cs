using System;

namespace Hybrid
{
    public abstract class InputDevice
    {
        internal virtual void OnEvent(SDL.Event e) { }
        internal virtual void OnDispose() { }
        internal virtual void OnReset() { }
    }
}