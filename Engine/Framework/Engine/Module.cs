using System;

namespace Hybrid.Internal
{
    // Module
    public abstract class Module
    {
        internal virtual void OnEvent(SDL.Event e) {}
        internal virtual void OnInitialize() {}
        internal virtual void OnRender() {}
        internal virtual void OnUpdate() {}
        internal virtual void OnDestroy() {}
        
        internal Module()
        {
            
        }
    }
}