using System;

namespace Hybrid
{
    // Resource
    public abstract class Resource : Object
    {
        public string Path { get; internal set; } = "Unknown";
    }
}