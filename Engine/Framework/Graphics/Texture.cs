using System;

namespace Hybrid
{
    public unsafe class Texture : IContentResource
    {
        public bool disposed { get; set; }
        internal SDL.Texture* Handle;
        
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool dispose)
        {
            if (disposed) return;
            disposed = true;

            if (dispose)
            {
                // Dispose
                SDL.DestroyTexture(Handle);
            }
        }

        ~Texture()
        {
            Dispose(true);
        }
    }
}