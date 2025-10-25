using System;

namespace Hybrid
{
    public unsafe class Font : IContentResource
    {
        public bool disposed { get; set; }
        internal SDL.Font* Handle;
        
        
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
                SDL_ttf.CloseFont(Handle);
            }
        }

        ~Font()
        {
            Dispose(true);
        }
    }
}