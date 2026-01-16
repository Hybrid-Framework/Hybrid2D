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
        
        
        internal Wave(string path)
        {
            path = Path.Combine(SDL.GetBasePath() + path);
            {
                Handle = SDL_mixer.LoadAudio(Audio.Handle, path, false);

                if (Handle == null)
                {
                    throw new Exception($"Failed to load wave '{path}': {SDL.GetError()}");
                }

                Stereo = new SDL_mixer.StereoGains(1, 1);
                Track = SDL_mixer.CreateTrack(Audio.Handle);
                SDL_mixer.SetTrackAudio(Track, Handle);
            }
        }
    }

    // Wave Management
    public unsafe partial class Wave
    {
        public static Wave CreateWave(string path)
        {
            return new Wave(path);
        }

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
        public static void SetPlaybackPosition(Wave wave, long ms)
        {
            var frames = SDL_mixer.TrackMSToFrames(wave.Track, ms);
            {
                SDL_mixer.SetTrackPlaybackPosition(wave.Track, frames);
            }
        }
        
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
        
        public static void SetVolume(Wave wave, float volume)
        {
            SDL_mixer.SetTrackGain(wave.Track, Maths.Clamp(volume, 0, 1));
        }
        
        public static float GetVolume(Wave wave)
        {
            return SDL_mixer.GetTrackGain(wave.Track);
        }
        
        public static void SetPitch(Wave wave, float pitch)
        {
            SDL_mixer.SetTrackFrequencyRatio(wave.Track, pitch);
        }

        public static float GetPitch(Wave wave)
        {
            return SDL_mixer.GetTrackFrequencyRatio(wave.Track);
        }

        public static void SetPan(Wave wave, float pan)
        {
            pan = Math.Clamp(pan, 0f, 1f);

            float angle = pan * MathF.PI * 0.5f;
            float left  = MathF.Cos(angle);
            float right = MathF.Sin(angle);

            wave.Stereo = new SDL_mixer.StereoGains(left, right);
            SDL_mixer.SetTrackStereo(wave.Track, wave.Stereo);
        }
        
        public static float GetPan(Wave wave)
        {
            return Math.Clamp(wave.Stereo.right, 0f, 1f);
        }

        public static void Play(Wave wave)
        {
            SDL_mixer.PlayTrack(wave.Track, 0);
        }
        
        public static void Pause(Wave wave)
        {
            SDL_mixer.PauseTrack(wave.Track);
        }

        public static void Resume(Wave wave)
        {
            SDL_mixer.ResumeTrack(wave.Track);
        }

        public static void Stop(Wave wave, long ms = 0)
        {
            var frames = SDL_mixer.TrackMSToFrames(wave.Track, ms);
            {
                SDL_mixer.StopTrack(wave.Track, frames);
            }
        }
        
        public static void SetLoop(Wave wave, bool loop)
        {
            SDL_mixer.SetTrackLoops(wave.Track, loop ? -1 : 0);
        }
        
        public static bool GetLoop(Wave wave)
        {
            return SDL_mixer.TrackLooping(wave.Track);
        }
        
        public static bool IsPlaying(Wave wave)
        {
            return SDL_mixer.TrackPlaying(wave.Track);
        }
    }
}