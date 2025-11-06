using System;

namespace Hybrid
{
    public class Module
    {
        internal Module()
        {
            Engine.Modules.Add(this);
        }
        
        internal virtual void Start()
        {
            
        }

        internal virtual void Update()
        {
            
        }

        internal virtual void Dispose()
        {
            
        }

        internal virtual void OnEvent(SDL.Event e)
        {
            
        }
    }
}