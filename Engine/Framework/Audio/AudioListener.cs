using System;

namespace Hybrid
{
    public unsafe class AudioListener
    {
        private SDL.Mixer* _handle;
        internal SDL.Mixer* Handle
        {
            get => _handle;
            set => _handle = value;
        }
        
        public AudioListener()
        {
            SDL.AudioSpec spec = new SDL.AudioSpec()
            {
                format = SDL.AudioFormat.S16,
                channels = 2,
                freq = 44100,
            };
            
            Handle = SDL_mixer.CreateMixerDevice(SDL.DefaultPlaybackDevice, spec);

            if (Handle == null)
            {
                throw new Exception($"Failed to create mixer device: {SDL.GetError()}");
            }
        }
    }
}