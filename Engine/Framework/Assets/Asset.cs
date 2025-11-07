using System;

namespace Hybrid
{
    // Asset
    public class Asset
    {
        public string Name { get; set; }
        
        internal Asset()
        {
            Name = GetType().Name;
        }
        
        internal virtual void Dispose()
        {
            
        }
    }
}