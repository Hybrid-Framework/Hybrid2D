using System;

namespace Hybrid
{
    public abstract class Disposable : IDisposable
    {
        public bool Disposed { get; private set; }
        
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Disposed) return;
            Disposed = true;

            if (disposing)
            {
                OnDispose();
            }
        }

        internal virtual void OnDispose()
        {
            
        }

        ~Disposable()
        {
            Dispose(false);
        }
    }
}