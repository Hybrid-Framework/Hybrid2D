using System;

namespace Hybrid
{
    public unsafe class AudioClip : IContentResource
    {
        public bool disposed { get; set; }
        internal SDL.Audio* Handle;
        
        
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
                SDL_mixer.DestroyAudio(Handle);
            }
        }

        ~AudioClip()
        {
            Dispose(true);
        }
    }
}