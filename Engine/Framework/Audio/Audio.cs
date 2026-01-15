using System.Collections.Generic;
using System;

namespace Hybrid
{
    // Internal
    public sealed unsafe partial class Audio : Module
    {
        internal Audio() { }
        
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

    // Audio API
    public unsafe partial class Audio
    {
        public static void SetVolume(float volume)
        {
            SDL_mixer.SetMasterGain(Handle, volume);
        }

        public static float GetVolume()
        {
            return SDL_mixer.GetMasterGain(Handle);
        }

        public static void Pause()
        {
            SDL_mixer.PauseAllTracks(Handle);
        }

        public static void Resume()
        {
            SDL_mixer.ResumeAllTracks(Handle);
        }

        public static void Stop(long ms)
        {
            SDL_mixer.StopAllTracks(Handle, ms);
        }
    }
}