using System;

namespace Hybrid
{
    internal abstract class InputDevice
    {
        internal virtual void OnEvent(SDL.Event e) { }
        internal virtual void OnStartOfFrame() { }
        internal virtual void Destroy() { }
    }
}