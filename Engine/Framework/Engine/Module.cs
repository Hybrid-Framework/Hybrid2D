using System;

namespace Hybrid
{
    // Module
    public class Module : Disposable
    {
        internal Module()
        {
            Engine.Modules.Add(this);
        }
        
        internal virtual void OnEvent(SDL.Event e)
        {
            
        }
    }
}