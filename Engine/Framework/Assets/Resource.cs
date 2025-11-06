using System;

namespace Hybrid
{
    public class Resource
    {
        public string Path { get; set; }
        
        internal virtual void Dispose()
        {
            
        }
    }
}