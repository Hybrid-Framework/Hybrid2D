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
        // Create new sound instance
        public static Sound CreateSound(string path)
        {
            return new Sound(path);
        }

        // Destroy existing sound instance
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
        // Set sound playback position
        public static void SetPlaybackPosition(Sound sound, long ms)
        {
            var frames = SDL_mixer.TrackMSToFrames(sound.Track, ms);
            {
                SDL_mixer.SetTrackPlaybackPosition(sound.Track, frames);
            }
        }
        
        // Get sound playback position
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
        
        // Get sound remaining time in ms 
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
        
        // Get sound duration time in ms
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
        
        // Set sound volume
        public static void SetVolume(Sound sound, float volume)
        {
            SDL_mixer.SetTrackGain(sound.Track, Maths.Clamp(volume, 0, 1));
        }
        
        // Get sound volume
        public static float GetVolume(Sound sound)
        {
            return SDL_mixer.GetTrackGain(sound.Track);
        }
        
        // Set sound pitch
        public static void SetPitch(Sound sound, float pitch)
        {
            SDL_mixer.SetTrackFrequencyRatio(sound.Track, pitch);
        }

        // Get sound pitch
        public static float GetPitch(Sound sound)
        {
            return SDL_mixer.GetTrackFrequencyRatio(sound.Track);
        }

        // Set sound pan position (0 left, 0.5 center, 1 right)
        public static void SetPan(Sound sound, float pan)
        {
            pan = Math.Clamp(pan, 0f, 1f);

            float angle = pan * MathF.PI * 0.5f;
            float left  = MathF.Cos(angle);
            float right = MathF.Sin(angle);

            sound.Stereo = new SDL_mixer.StereoGains(left, right);
            SDL_mixer.SetTrackStereo(sound.Track, sound.Stereo);
        }
        
        // Get sound pan position
        public static float GetPan(Sound sound)
        {
            return Math.Clamp(sound.Stereo.right, 0f, 1f);
        }

        // Play sound
        public static void Play(Sound sound)
        {
            SDL_mixer.PlayTrack(sound.Track, 0);
        }
        
        // Pause sound
        public static void Pause(Sound sound)
        {
            SDL_mixer.PauseTrack(sound.Track);
        }

        // Resume sound
        public static void Resume(Sound sound)
        {
            SDL_mixer.ResumeTrack(sound.Track);
        }

        // Stop sound
        public static void Stop(Sound sound)
        {
            var frames = SDL_mixer.TrackMSToFrames(sound.Track, 0);
            {
                SDL_mixer.StopTrack(sound.Track, frames);
            }
        }
        
        // Stop sound with fade in ms
        public static void Stop(Sound sound, long ms)
        {
            var frames = SDL_mixer.TrackMSToFrames(sound.Track, ms);
            {
                SDL_mixer.StopTrack(sound.Track, frames);
            }
        }
        
        // Set sound looping
        public static void SetLoop(Sound sound, bool loop)
        {
            SDL_mixer.SetTrackLoops(sound.Track, loop ? -1 : 0);
        }
        
        // Get sound looping
        public static bool GetLoop(Sound sound)
        {
            return SDL_mixer.TrackLooping(sound.Track);
        }
        
        // Is sound playing
        public static bool IsPlaying(Sound sound)
        {
            return SDL_mixer.TrackPlaying(sound.Track);
        }
    }
}