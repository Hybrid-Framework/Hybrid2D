using System;

namespace Hybrid
{
    // Internal
    public unsafe partial class AudioClip : Resource
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

    // Audio Clip API
    public unsafe partial class AudioClip
    {
        internal AudioClip(SDL.Audio* handle)
        {
            Handle = handle;
        }
    }
}