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
        // Set master audio volume
        public static void SetAudioVolume(float volume)
        {
            SDL_mixer.SetMasterGain(Handle, volume);
        }

        // Get master audio volume
        public static float GetAudioVolume()
        {
            return SDL_mixer.GetMasterGain(Handle);
        }
        
        // Set master audio pitch
        public static void SetAudioPitch(float pitch)
        {
            SDL_mixer.SetMasterFrequencyRatio(Handle, pitch);
        }

        // Get master audio pitch
        public static float GetAudioPitch()
        {
            return SDL_mixer.GetMasterFrequencyRatio(Handle);
        }

        // Pause master audio
        public static void PauseAudio()
        {
            SDL_mixer.PauseAllTracks(Handle);
        }

        // Resume master audio
        public static void ResumeAudio()
        {
            SDL_mixer.ResumeAllTracks(Handle);
        }

        // Stop master audio
        public static void StopAudio()
        {
            SDL_mixer.StopAllTracks(Handle, 0);
        }
        
        // Stop master audio with fade in ms
        public static void StopAudio(long ms)
        {
            SDL_mixer.StopAllTracks(Handle, ms);
        }
    }
}