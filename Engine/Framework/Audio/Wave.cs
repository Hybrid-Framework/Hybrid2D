using System.IO;
using System;

namespace Hybrid
{
    // Internal
    public sealed unsafe partial class Wave
    {
        internal SDL_mixer.StereoGains Stereo { get; set; }
        internal SDL.Audio* Handle { get; set; }
        internal SDL.Track* Track { get; set; }
        
        
        internal Wave(int hz, float amplitude, long ms)
        {
            Handle = SDL_mixer.CreateSineWaveAudio(Audio.Handle, hz, amplitude, ms);

            if (Handle == null)
            {
                throw new Exception($"Failed to create sine wave: {SDL.GetError()}");
            }

            Stereo = new SDL_mixer.StereoGains(1, 1);
            Track = SDL_mixer.CreateTrack(Audio.Handle);
            SDL_mixer.SetTrackAudio(Track, Handle);
        }
    }

    // Wave Management
    public unsafe partial class Wave
    {
        // Create new sine wave instance
        public static Wave CreateWave(int hz, float amplitude, long ms)
        {
            return new Wave(hz, amplitude, ms);
        }

        // Destroy existing sine wave instance
        public static void DestroyWave(Wave wave)
        {
            if (wave.Handle != null)
            {
                SDL_mixer.DestroyAudio(wave.Handle);
                wave.Handle = null;
            }

            if (wave.Track != null)
            {
                SDL_mixer.DestroyTrack(wave.Track);
            }
        }
    }

    // Wave API
    public unsafe partial class Wave
    {
        // Set sine wave playback position
        public static void SetPlaybackPosition(Wave wave, long ms)
        {
            var frames = SDL_mixer.TrackMSToFrames(wave.Track, ms);
            {
                SDL_mixer.SetTrackPlaybackPosition(wave.Track, frames);
            }
        }
        
        // Get sine wave playback position
        public static long GetPlaybackPosition(Wave wave)
        {
            var frames = SDL_mixer.GetTrackPlaybackPosition(wave.Track);
            {
                var ms = SDL_mixer.TrackFramesToMS(wave.Track, frames);
                {
                    return ms;
                }
            }
        }
        
        // Get sine wave remaining time in ms
        public static long GetRemaining(Wave wave)
        {
            var frames = SDL_mixer.GetTrackRemaining(wave.Track);
            {
                var ms = SDL_mixer.TrackFramesToMS(wave.Track, frames);
                {
                    return ms;
                }
            }
        }
        
        // Get sine wave duration time in ms
        public static long GetDuration(Wave wave)
        {
            var frames = SDL_mixer.GetAudioDuration(wave.Handle);
            {
                var ms = SDL_mixer.AudioFramesToMS(wave.Handle, frames);
                {
                    return ms;
                }
            }
        }
        
        // Set sine wave volume
        public static void SetVolume(Wave wave, float volume)
        {
            SDL_mixer.SetTrackGain(wave.Track, Maths.Clamp(volume, 0, 1));
        }
        
        // Get sine wave volume
        public static float GetVolume(Wave wave)
        {
            return SDL_mixer.GetTrackGain(wave.Track);
        }
        
        // Set sine wave pitch
        public static void SetPitch(Wave wave, float pitch)
        {
            SDL_mixer.SetTrackFrequencyRatio(wave.Track, pitch);
        }

        // Get sine wave pitch
        public static float GetPitch(Wave wave)
        {
            return SDL_mixer.GetTrackFrequencyRatio(wave.Track);
        }

        // Set sine wave pan position (0 left, 0.5 center, 1 right)
        public static void SetPan(Wave wave, float pan)
        {
            pan = Math.Clamp(pan, 0f, 1f);

            float angle = pan * MathF.PI * 0.5f;
            float left  = MathF.Cos(angle);
            float right = MathF.Sin(angle);

            wave.Stereo = new SDL_mixer.StereoGains(left, right);
            SDL_mixer.SetTrackStereo(wave.Track, wave.Stereo);
        }
        
        // Get sine wave pan position
        public static float GetPan(Wave wave)
        {
            return Math.Clamp(wave.Stereo.right, 0f, 1f);
        }

        // Play sine wave
        public static void Play(Wave wave)
        {
            SDL_mixer.PlayTrack(wave.Track, 0);
        }
        
        // Pause sine wave
        public static void Pause(Wave wave)
        {
            SDL_mixer.PauseTrack(wave.Track);
        }

        // Resume sine wave
        public static void Resume(Wave wave)
        {
            SDL_mixer.ResumeTrack(wave.Track);
        }

        // Stop sine wave
        public static void Stop(Wave wave)
        {
            var frames = SDL_mixer.TrackMSToFrames(wave.Track, 0);
            {
                SDL_mixer.StopTrack(wave.Track, frames);
            }
        }
        
        // Stop sine wave with fade in ms
        public static void Stop(Wave wave, long ms)
        {
            var frames = SDL_mixer.TrackMSToFrames(wave.Track, ms);
            {
                SDL_mixer.StopTrack(wave.Track, frames);
            }
        }
        
        // Set sine wave looping
        public static void SetLoop(Wave wave, bool loop)
        {
            SDL_mixer.SetTrackLoops(wave.Track, loop ? -1 : 0);
        }
        
        // Get sine wave looping
        public static bool GetLoop(Wave wave)
        {
            return SDL_mixer.TrackLooping(wave.Track);
        }
        
        // Is sine wave playing
        public static bool IsPlaying(Wave wave)
        {
            return SDL_mixer.TrackPlaying(wave.Track);
        }
    }
}