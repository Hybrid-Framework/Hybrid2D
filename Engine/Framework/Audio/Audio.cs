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
        public static void SetAudioVolume(float volume)
        {
            SDL_mixer.SetMasterGain(Handle, volume);
        }

        public static float GetAudioVolume()
        {
            return SDL_mixer.GetMasterGain(Handle);
        }
        
        public static void SetAudioPitch(float pitch)
        {
            SDL_mixer.SetMasterFrequencyRatio(Handle, pitch);
        }

        public static float GetAudioPitch()
        {
            return SDL_mixer.GetMasterFrequencyRatio(Handle);
        }

        public static void PauseAudio()
        {
            SDL_mixer.PauseAllTracks(Handle);
        }

        public static void ResumeAudio()
        {
            SDL_mixer.ResumeAllTracks(Handle);
        }

        public static void StopAudio(long ms)
        {
            SDL_mixer.StopAllTracks(Handle, ms);
        }
    }
}