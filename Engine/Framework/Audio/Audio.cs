using System.IO;
using System;

namespace Hybrid
{
    // Internal
    public sealed unsafe partial class Audio
    {
        internal SDL.Audio* Handle { get; set; }
        internal Track Track { get; set; }

        
        internal Audio(SDL.Audio* handle)
        {
            Handle = handle;
            {
                Track = new Track(SDL_mixer.CreateTrack(Mixer.Handle));
                {
                    SDL_mixer.SetTrackAudio(Track.Handle, Handle);
                }
            }
        }
    }

    // Create & Destroy
    public unsafe partial class Audio
    {
        public static Audio CreateAudio(string path)
        {
            path = Path.Combine(SDL.GetBasePath() + path);
            {
                var audio = SDL_mixer.LoadAudio(Mixer.Handle, path, false);

                if (audio == null)
                {
                    throw new Exception($"Failed to load audio '{path}': {SDL.GetError()}");
                }

                return new Audio(audio);
            }
        }

        public static void DestroyAudio(Audio audio)
        {
            if (audio != null)
            {
                if (audio.Handle != null)
                {
                    SDL_mixer.DestroyAudio(audio.Handle);
                    {
                        audio.Handle = null;
                    }
                }

                if (audio.Track.Handle != null)
                {
                    SDL_mixer.DestroyTrack(audio.Track.Handle);
                    {
                        audio.Track.Handle = null;
                    }
                }
            }
        }
    }
    
    // Audio API
    public unsafe partial class Audio
    {
        public static long GetRemaining(Audio audio)
        {
            var frames = SDL_mixer.GetTrackRemaining(audio.Track.Handle);
            {
                var ms = SDL_mixer.TrackFramesToMS(audio.Track.Handle, frames);
                {
                    return ms;
                }
            }
        }
        
        public static long GetDuration(Audio audio)
        {
            var frames = SDL_mixer.GetAudioDuration(audio.Handle);
            {
                var ms = SDL_mixer.AudioFramesToMS(audio.Handle, frames);
                {
                    return ms;
                }
            }
        }
        
        public static void SetVolume(Audio audio, float volume)
        {
            SDL_mixer.SetTrackGain(audio.Track.Handle, Maths.Clamp(volume, 0, 1));
        }
        
        public static void SetMasterVolume(float volume)
        {
            SDL_mixer.SetMasterGain(Mixer.Handle, Maths.Clamp(volume, 0, 1));
        }
        
        public static float GetVolume(Audio audio)
        {
            return SDL_mixer.GetTrackGain(audio.Track.Handle);
        }

        public static float GetMasterVolume()
        {
            return SDL_mixer.GetMasterGain(Mixer.Handle);
        }

        public static void Play(Audio audio)
        {
            SDL_mixer.PlayTrack(audio.Track.Handle, 0);
        }
        
        public static void Pause(Audio audio)
        {
            SDL_mixer.PauseTrack(audio.Track.Handle);
        }

        public static void Resume(Audio audio)
        {
            SDL_mixer.ResumeTrack(audio.Track.Handle);
        }

        public static void Stop(Audio audio, long fade = 0)
        {
            var frames = SDL_mixer.TrackMSToFrames(audio.Track.Handle, fade);
            {
                SDL_mixer.StopTrack(audio.Track.Handle, frames);
            }
        }
        
        public static bool IsPlaying(Audio audio)
        {
            return SDL_mixer.TrackPlaying(audio.Track.Handle);
        }
    }
}