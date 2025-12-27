using System;

namespace Hybrid
{
    internal class InputDevice
    {
        internal virtual void OnEvent(SDL.Event e) { }
        internal virtual void OnDispose() { }
        internal virtual void OnReset() { }
    }
}