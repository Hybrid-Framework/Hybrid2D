using System;

namespace Hybrid
{
    // Resource
    public class Resource
    {
        public string Name { get; set; }

        public Resource()
        {
            Name = GetType().Name;
        }

        internal virtual void OnDispose()
        {
            
        }
    }
}