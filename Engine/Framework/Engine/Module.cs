using System;

namespace Hybrid
{
    // Module
    public class Module
    {
        internal Module()
        {
            Engine.Modules.Add(this);
        }
        
        internal virtual void OnEvent(SDL.Event e)
        {
            
        }

        internal virtual void OnFrameStart()
        {
            
        }

        internal virtual void OnFrameEnd()
        {
            
        }
        
        internal virtual void OnStart()
        {
            
        }

        internal virtual void OnUpdate()
        {
            
        }
        
        internal virtual void OnRender()
        {
            
        }
        
        internal virtual void Dispose()
        {
            
        }
    }
}