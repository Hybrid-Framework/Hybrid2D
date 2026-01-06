using System;

namespace Hybrid
{
    // Resource
    public abstract class Resource
    {
        public string Path { get; internal set; } = "Unknown";

        internal virtual void OnDispose() { }
    }
}