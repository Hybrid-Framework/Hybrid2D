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
        
        internal virtual void Dispose()
        {
            
        }
    }
}