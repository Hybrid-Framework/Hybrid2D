using System.IO;
using System;

namespace Hybrid
{
    // Internal
    public sealed unsafe partial class Music
    {
        internal SDL_mixer.StereoGains Stereo { get; set; }
        internal SDL.Audio* Handle { get; set; }
        internal SDL.Track* Track { get; set; }
        
        
        internal Music(string path)
        {
            path = Path.Combine(SDL.GetBasePath() + path);
            {
                Handle = SDL_mixer.LoadAudio(Audio.Handle, path, false);

                if (Handle == null)
                {
                    throw new Exception($"Failed to load music '{path}': {SDL.GetError()}");
                }

                Stereo = new SDL_mixer.StereoGains(1, 1);
                Track = SDL_mixer.CreateTrack(Audio.Handle);
                SDL_mixer.SetTrackAudio(Track, Handle);
            }
        }
    }

    // Music Management
    public unsafe partial class Music
    {
        // Create new music instance
        public static Music CreateMusic(string path)
        {
            return new Music(path);
        }

        // Destroy existing music instance
        public static void DestroyMusic(Music music)
        {
            if (music.Handle != null)
            {
                SDL_mixer.DestroyAudio(music.Handle);
                music.Handle = null;
            }

            if (music.Track != null)
            {
                SDL_mixer.DestroyTrack(music.Track);
            }
        }
    }

    // Music API
    public unsafe partial class Music
    {
        // Set music playback position
        public static void SetPlaybackPosition(Music music, long ms)
        {
            var frames = SDL_mixer.TrackMSToFrames(music.Track, ms);
            {
                SDL_mixer.SetTrackPlaybackPosition(music.Track, frames);
            }
        }
        
        // Get music playback position
        public static long GetPlaybackPosition(Music music)
        {
            var frames = SDL_mixer.GetTrackPlaybackPosition(music.Track);
            {
                var ms = SDL_mixer.TrackFramesToMS(music.Track, frames);
                {
                    return ms;
                }
            }
        }
        
        // Get music remaining time in ms 
        public static long GetRemaining(Music music)
        {
            var frames = SDL_mixer.GetTrackRemaining(music.Track);
            {
                var ms = SDL_mixer.TrackFramesToMS(music.Track, frames);
                {
                    return ms;
                }
            }
        }
        
        // Get music duration time in ms
        public static long GetDuration(Music music)
        {
            var frames = SDL_mixer.GetAudioDuration(music.Handle);
            {
                var ms = SDL_mixer.AudioFramesToMS(music.Handle, frames);
                {
                    return ms;
                }
            }
        }
        
        // Set music volume
        public static void SetVolume(Music music, float volume)
        {
            SDL_mixer.SetTrackGain(music.Track, Maths.Clamp(volume, 0, 1));
        }
        
        // Get music volume
        public static float GetVolume(Music music)
        {
            return SDL_mixer.GetTrackGain(music.Track);
        }
        
        // Set music pitch
        public static void SetPitch(Music music, float pitch)
        {
            SDL_mixer.SetTrackFrequencyRatio(music.Track, pitch);
        }

        // Get music pitch
        public static float GetPitch(Music music)
        {
            return SDL_mixer.GetTrackFrequencyRatio(music.Track);
        }

        // Set music pan position (0 left, 0.5 center, 1 right)
        public static void SetPan(Music music, float pan)
        {
            pan = Math.Clamp(pan, 0f, 1f);

            float angle = pan * MathF.PI * 0.5f;
            float left  = MathF.Cos(angle);
            float right = MathF.Sin(angle);

            music.Stereo = new SDL_mixer.StereoGains(left, right);
            SDL_mixer.SetTrackStereo(music.Track, music.Stereo);
        }
        
        // Get music pan position
        public static float GetPan(Music music)
        {
            return Math.Clamp(music.Stereo.right, 0f, 1f);
        }

        // Play music
        public static void Play(Music music)
        {
            SDL_mixer.PlayTrack(music.Track, 0);
        }
        
        // Pause music
        public static void Pause(Music music)
        {
            SDL_mixer.PauseTrack(music.Track);
        }

        // Resume music
        public static void Resume(Music music)
        {
            SDL_mixer.ResumeTrack(music.Track);
        }

        // Stop music
        public static void Stop(Music music)
        {
            var frames = SDL_mixer.TrackMSToFrames(music.Track, 0);
            {
                SDL_mixer.StopTrack(music.Track, frames);
            }
        }
        
        // Stop music with fade in ms
        public static void Stop(Music music, long ms)
        {
            var frames = SDL_mixer.TrackMSToFrames(music.Track, ms);
            {
                SDL_mixer.StopTrack(music.Track, frames);
            }
        }
        
        // Set music looping
        public static void SetLoop(Music music, bool loop)
        {
            SDL_mixer.SetTrackLoops(music.Track, loop ? -1 : 0);
        }
        
        // Get music looping
        public static bool GetLoop(Music music)
        {
            return SDL_mixer.TrackLooping(music.Track);
        }
        
        // Is music playing
        public static bool IsPlaying(Music music)
        {
            return SDL_mixer.TrackPlaying(music.Track);
        }
    }
}