using System;

namespace Hybrid
{
    // Internal
    public unsafe partial class Audio : Module<Audio>
    {
        private Audio() { }
        
        // Create
        internal override void OnCreate()
        {
            Console.WriteLine("Audio Created");
            
            Handle = SDL_mixer.CreateMixerDevice(SDL.DefaultPlaybackDevice, new SDL.AudioSpec()
            {
                format = SDL.AudioFormat.S16,
                channels = 2,
                freq = 44100
            });
        }
        
        // Destroy
        internal override void OnDestroy()
        {
            Console.WriteLine("Audio Destroyed");
            
            if (Handle != null)
            {
                SDL_mixer.DestroyMixer(Handle);
                Handle = null;
            }
        }
    }

    // Audio API
    public unsafe partial class Audio
    {
        // SDL Mixer Handle
        internal static SDL.Mixer* Handle
        {
            private set;
            get;
        }
    }
}