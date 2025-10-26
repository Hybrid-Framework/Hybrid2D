using System;

namespace Hybrid
{
    public interface IContentResource : IDisposable
    {
        public bool Disposed { get; set; }
    }
}