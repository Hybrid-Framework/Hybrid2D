using System;

namespace Hybrid
{
    internal sealed unsafe class Mixer : Module
    {
        internal Mixer() { }
        
        internal static SDL.Mixer* Handle
        {
            get; private set;
        }

        // Initialize
        internal override void OnInitialize()
        {
            Handle = SDL_mixer.CreateMixerDevice(SDL.DefaultPlaybackDevice, new SDL.AudioSpec()
            {
                format = SDL.AudioFormat.S16,
                channels = 2,
                freq = 44100
            });
        }
        
        // Dispose
        internal override void OnDispose()
        {
            if (Handle != null)
            {
                SDL_mixer.DestroyMixer(Handle);
                Handle = null;
            }
        }
    }
}