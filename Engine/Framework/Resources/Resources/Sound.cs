using System;

namespace Hybrid
{
    // Sound
    public unsafe class Sound : Resource
    {
        // SDL Audio Handle
        internal SDL.Audio* Handle
        {
            private set;
            get;
        }
        

        internal Sound(SDL.Audio* handle)
        {
            Handle = handle;
        }

        internal override void OnDestroy()
        {
            if (Handle != null)
            {
                SDL_mixer.DestroyAudio(Handle);
                Handle = null;
            }
        }
    }
}