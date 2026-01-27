using System.Collections.Generic;
using System;

namespace Hybrid
{
    public abstract class Module
    {
        internal static List<Module> Modules { get; set; } = new List<Module>();

        internal Module()
        {
            Modules.Add(this);
        }
        
        internal virtual void OnEvent(SDL.Event e) { }
        internal virtual void OnStartOfFrame() { }
        internal virtual void OnInitialize() { }
        internal virtual void OnUpdate() { }
        internal virtual void OnRender() { }
        internal virtual void OnEndOfFrame() { }
        internal virtual void Destroy() { }
    }
}