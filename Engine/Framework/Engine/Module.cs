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
        
        internal virtual void OnInitialize()
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