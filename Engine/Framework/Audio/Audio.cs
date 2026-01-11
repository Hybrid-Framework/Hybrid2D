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

    // Static Audio
    public unsafe partial class Audio
    {
        public static Audio Create(string path)
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

        public static void Destroy(Audio audio)
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
    
    // Public Audio
    public sealed unsafe partial class Audio
    {
        public long GetRemaining()
        {
            var frames = SDL_mixer.GetTrackRemaining(Track.Handle);
            {
                var ms = SDL_mixer.TrackFramesToMS(Track.Handle, frames);
                {
                    return ms;
                }
            }
        }
        
        public long GetDuration()
        {
            var frames = SDL_mixer.GetAudioDuration(Handle);
            {
                var ms = SDL_mixer.AudioFramesToMS(Handle, frames);
                {
                    return ms;
                }
            }
        }
        
        public void SetMasterVolume(float volume)
        {
            SDL_mixer.SetMasterGain(Mixer.Handle, Maths.Clamp(volume, 0, 1));
        }

        public float GetMasterVolume()
        {
            return SDL_mixer.GetMasterGain(Mixer.Handle);
        }
        
        public void SetVolume(float volume)
        {
            SDL_mixer.SetTrackGain(Track.Handle, Maths.Clamp(volume, 0, 1));
        }

        public float GetVolume()
        {
            return SDL_mixer.GetTrackGain(Track.Handle);
        }
        
        public bool IsPlaying()
        {
            return SDL_mixer.TrackPlaying(Track.Handle);
        }

        public void Play()
        {
            SDL_mixer.PlayTrack(Track.Handle, 0);
        }
        
        public void Pause()
        {
            SDL_mixer.PauseTrack(Track.Handle);
        }

        public void Resume()
        {
            SDL_mixer.ResumeTrack(Track.Handle);
        }

        public void Stop(long fade = 0)
        {
            var frames = SDL_mixer.TrackMSToFrames(Track.Handle, fade);
            {
                SDL_mixer.StopTrack(Track.Handle, frames);
            }
        }
    }
}