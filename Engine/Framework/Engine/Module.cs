using System;

namespace Hybrid
{
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