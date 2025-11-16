using System;

namespace Hybrid
{
    // Disposable
    public abstract class Disposable : IDisposable
    {
        internal bool Disposed { get; private set; }
        
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        internal virtual void OnDispose()
        {
            // What happens on dispose?
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

        ~Disposable()
        {
            Dispose(false);
        }
    }
}