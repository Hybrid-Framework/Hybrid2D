using System;

namespace Hybrid
{
    // Track
    internal sealed unsafe class Track : Resource
    {
        internal SDL.Track* Handle
        {
            get; set;
        }
        
        internal Track(SDL.Audio* audio)
        {
            Handle = SDL_mixer.CreateTrack(Audio.Handle);

            if (Handle == null)
            {
                throw new Exception("Failed to create track for audio");
            }

            SDL_mixer.SetTrackAudio(Handle, audio);
        }

        internal override void Destroy()
        {
            if (Handle != null)
            {
                SDL_mixer.DestroyTrack(Handle);
                Handle = null;
            }
        }
    }
}