using System.Collections.Generic;
using System;

namespace Hybrid
{
    public abstract class Module
    {
        private static List<Module> Modules { get; set; } = new List<Module>();
        
        internal virtual void OnEvent(SDL.Event e) { }
        internal virtual void OnStartOfFrame() { }
        internal virtual void OnInitialize() { }
        internal virtual void OnUpdate() { }
        internal virtual void OnRender() { }
        internal virtual void OnEndOfFrame() { }
        internal virtual void OnDispose() { }

        internal Module()
        {
            Modules.Add(this);
        }

        internal static IReadOnlyList<Module> GetModules()
        {
            return Modules;
        }
    }
}