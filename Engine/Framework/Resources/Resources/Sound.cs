using System;

namespace Hybrid
{
    // Internal
    public unsafe partial class Sound : Resource
    {
        // SDL Audio Handle
        internal SDL.Audio* Handle
        {
            private set;
            get;
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

    // Sound API
    public unsafe partial class Sound
    {
        internal Sound(SDL.Audio* handle)
        {
            Handle = handle;
        }
    }
}