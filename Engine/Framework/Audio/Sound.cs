using System.IO;
using System;

namespace Hybrid
{
    // Internal
    public sealed unsafe partial class Sound
    {
        internal SDL_mixer.StereoGains Stereo { get; set; }
        internal SDL.Audio* Handle { get; set; }
        internal SDL.Track* Track { get; set; }
        
        
        internal Sound(string path)
        {
            path = Path.Combine(SDL.GetBasePath() + path);
            {
                Handle = SDL_mixer.LoadAudio(Audio.Handle, path, false);

                if (Handle == null)
                {
                    throw new Exception($"Failed to load sound '{path}': {SDL.GetError()}");
                }

                Stereo = new SDL_mixer.StereoGains(1, 1);
                Track = SDL_mixer.CreateTrack(Audio.Handle);
                SDL_mixer.SetTrackAudio(Track, Handle);
            }
        }
    }

    // Sound Management
    public unsafe partial class Sound
    {
        public static Sound CreateSound(string path)
        {
            return new Sound(path);
        }

        public static void DestroySound(Sound sound)
        {
            if (sound.Handle != null)
            {
                SDL_mixer.DestroyAudio(sound.Handle);
                sound.Handle = null;
            }

            if (sound.Track != null)
            {
                SDL_mixer.DestroyTrack(sound.Track);
            }
        }
    }

    // Sound API
    public unsafe partial class Sound
    {
        public static void SetPlaybackPosition(Sound sound, long ms)
        {
            var frames = SDL_mixer.TrackMSToFrames(sound.Track, ms);
            {
                SDL_mixer.SetTrackPlaybackPosition(sound.Track, frames);
            }
        }
        
        public static long GetPlaybackPosition(Sound sound)
        {
            var frames = SDL_mixer.GetTrackPlaybackPosition(sound.Track);
            {
                var ms = SDL_mixer.TrackFramesToMS(sound.Track, frames);
                {
                    return ms;
                }
            }
        }
        
        public static long GetRemaining(Sound sound)
        {
            var frames = SDL_mixer.GetTrackRemaining(sound.Track);
            {
                var ms = SDL_mixer.TrackFramesToMS(sound.Track, frames);
                {
                    return ms;
                }
            }
        }
        
        public static long GetDuration(Sound sound)
        {
            var frames = SDL_mixer.GetAudioDuration(sound.Handle);
            {
                var ms = SDL_mixer.AudioFramesToMS(sound.Handle, frames);
                {
                    return ms;
                }
            }
        }
        
        public static void SetVolume(Sound sound, float volume)
        {
            SDL_mixer.SetTrackGain(sound.Track, Maths.Clamp(volume, 0, 1));
        }
        
        public static float GetVolume(Sound sound)
        {
            return SDL_mixer.GetTrackGain(sound.Track);
        }
        
        public static void SetPitch(Sound sound, float pitch)
        {
            SDL_mixer.SetTrackFrequencyRatio(sound.Track, pitch);
        }

        public static float GetPitch(Sound sound)
        {
            return SDL_mixer.GetTrackFrequencyRatio(sound.Track);
        }

        public static void SetPan(Sound sound, float pan)
        {
            pan = Math.Clamp(pan, 0f, 1f);

            float angle = pan * MathF.PI * 0.5f;
            float left  = MathF.Cos(angle);
            float right = MathF.Sin(angle);

            sound.Stereo = new SDL_mixer.StereoGains(left, right);
            SDL_mixer.SetTrackStereo(sound.Track, sound.Stereo);
        }
        
        public static float GetPan(Sound sound)
        {
            return Math.Clamp(sound.Stereo.right, 0f, 1f);
        }

        public static void Play(Sound sound)
        {
            SDL_mixer.PlayTrack(sound.Track, 0);
        }
        
        public static void Pause(Sound sound)
        {
            SDL_mixer.PauseTrack(sound.Track);
        }

        public static void Resume(Sound sound)
        {
            SDL_mixer.ResumeTrack(sound.Track);
        }

        public static void Stop(Sound sound, long ms = 0)
        {
            var frames = SDL_mixer.TrackMSToFrames(sound.Track, ms);
            {
                SDL_mixer.StopTrack(sound.Track, frames);
            }
        }
        
        public static void SetLoop(Sound sound, bool loop)
        {
            SDL_mixer.SetTrackLoops(sound.Track, loop ? -1 : 0);
        }
        
        public static bool GetLoop(Sound sound)
        {
            return SDL_mixer.TrackLooping(sound.Track);
        }
        
        public static bool IsPlaying(Sound sound)
        {
            return SDL_mixer.TrackPlaying(sound.Track);
        }
    }
}