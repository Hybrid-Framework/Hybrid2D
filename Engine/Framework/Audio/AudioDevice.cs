using System;

namespace Hybrid
{
    // Audio Device
    internal unsafe partial class AudioDevice : Module
    {
        internal SDL.Mixer* Handle { get; private set; }
        

        internal AudioDevice(Config config)
        {
            // Create Audio Device
            Handle = SDL_mixer.CreateMixerDevice(SDL.DefaultPlaybackDevice, new SDL.AudioSpec()
            {
                format = SDL.AudioFormat.S16,
                channels = 2,
                freq = 44100
            });
        }

        internal override void OnDispose()
        {
            if (Handle != null)
            {
                SDL_mixer.DestroyMixer(Handle);
                Handle = null;
            }
        }
    }

    // Properties
    internal unsafe partial class AudioDevice : Module
    {
        internal float Volume
        {
            set => SDL_mixer.SetMasterGain(Handle, value);
            get => SDL_mixer.GetMasterGain(Handle);
        }
    }
}