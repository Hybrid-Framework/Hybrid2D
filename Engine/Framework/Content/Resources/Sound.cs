using System;

namespace Hybrid
{
    public unsafe class Sound : Resource
    {
        internal SDL.Audio* Handle { get; private set; }

        internal Sound(SDL.Audio* handle)
        {
            Handle = handle;
        }

        internal override void OnDispose()
        {
            if (Handle != null)
            {
                SDL_mixer.DestroyAudio(Handle);
                Handle = null;
            }
        }
    }
}