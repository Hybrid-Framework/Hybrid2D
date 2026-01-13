using System;

namespace Hybrid
{
    internal sealed unsafe class Mixer : Resource
    {
        internal SDL.Mixer* Handle
        {
            get; set;
        }
        
        internal Mixer()
        {
            Handle = SDL_mixer.CreateMixerDevice(SDL.DefaultPlaybackDevice, new SDL.AudioSpec()
            {
                format = SDL.AudioFormat.S16,
                channels = 2,
                freq = 44100
            });
        }

        internal override void Destroy()
        {
            if (Handle != null)
            {
                SDL_mixer.DestroyMixer(Handle);
                Handle = null;
            }
        }
    }
}