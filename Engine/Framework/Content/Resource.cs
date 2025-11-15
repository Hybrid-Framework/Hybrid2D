using System;

namespace Hybrid
{
    // Resource
    public class Resource : Disposable
    {
        public string Name { get; set; }

        public Resource()
        {
            Name = GetType().Name;
        }
    }
}