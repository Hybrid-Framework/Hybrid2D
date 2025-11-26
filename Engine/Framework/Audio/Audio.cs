using System;

namespace Hybrid
{
    internal unsafe class Audio : Module
    {
        // SDL Mixer Handle
        internal static SDL.Mixer* Handle
        {
            private set;
            get;
        }
        
        
        internal Audio()
        {
            // Create Audio Device
            Handle = SDL_mixer.CreateMixerDevice(SDL.DefaultPlaybackDevice, new SDL.AudioSpec()
            {
                format = SDL.AudioFormat.S16,
                channels = 2,
                freq = 44100
            });
        }

        internal override void OnDestroy()
        {
            Console.WriteLine("Audio Disposed");
            
            if (Handle != null)
            {
                SDL_mixer.DestroyMixer(Handle);
                Handle = null;
            }
        }
    }
}