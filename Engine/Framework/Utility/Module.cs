using System.Collections.Generic;
using System.Collections;
using System;

namespace Hybrid
{
    // Module
    public abstract class Module
    {
        internal virtual void OnEvent(SDL.Event e) {}
        internal virtual void OnInitialize() {}
        internal virtual void OnStartOfFrame() {}
        internal virtual void OnUpdate() {}
        internal virtual void OnRender() {}
        internal virtual void OnEndOfFrame() {}
        internal virtual void OnDispose() {}
    }
}