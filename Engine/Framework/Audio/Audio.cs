using System;

namespace Hybrid
{
    // Internal
    public sealed unsafe partial class Audio : Module<Audio>
    {
        private Audio() { }
        
        // Initialize
        internal override void OnInitialize()
        {
            Handle = SDL_mixer.CreateMixerDevice(SDL.DefaultPlaybackDevice, new SDL.AudioSpec()
            {
                format = SDL.AudioFormat.S16,
                channels = 2,
                freq = 44100
            });
            
            base.OnInitialize();
        }
        
        // Dispose
        internal override void OnDispose()
        {
            if (Handle != null)
            {
                SDL_mixer.DestroyMixer(Handle);
                Handle = null;
            }
            
            base.OnDispose();
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