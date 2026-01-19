using System.Collections.Generic;
using System;

namespace Hybrid
{
    // Internal
    internal sealed unsafe partial class Mixer : Module
    {
        internal Mixer() { }
        
        internal static SDL.Mixer* Handle
        {
            get; set;
        }

        // Initialize
        internal override void OnInitialize()
        {
            Handle = SDL_mixer.CreateMixerDevice(SDL.DefaultPlaybackDevice, new SDL.AudioSpec()
            {
                format = SDL.AudioFormat.S32,
                channels = 2,
                freq = 44100
            });
        }
        
        // Dispose
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