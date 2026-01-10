using System.IO;
using System;

namespace Hybrid
{
    public sealed unsafe class Audio
    {
        internal Track Track;
        
        internal SDL.Audio* Handle
        {
            get; set;
        }
        
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
        
        public static Audio LoadAudio(string path)
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

        public static void UnloadAudio(Audio audio)
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

        public static void SetMasterVolume(float volume)
        {
            SDL_mixer.SetMasterGain(Mixer.Handle, Maths.Clamp(volume, 0, 1));
        }

        public static float GetMasterVolume()
        {
            return SDL_mixer.GetMasterGain(Mixer.Handle);
        }

        public static void SetAudioVolume(Audio audio, float volume)
        {
            SDL_mixer.SetTrackGain(audio.Track.Handle, Maths.Clamp(volume, 0, 1));
        }

        public static float GetAudioVolume(Audio audio)
        {
            return SDL_mixer.GetTrackGain(audio.Track.Handle);
        }

        public static long GetAudioDuration(Audio audio)
        {
            var frames = SDL_mixer.GetAudioDuration(audio.Handle);
            {
                var ms = SDL_mixer.AudioFramesToMS(audio.Handle, frames);
                {
                    return ms;
                }
            }
        }

        public static float GetAudioRemainingDuration(Audio audio)
        {
            var frames = SDL_mixer.GetTrackRemaining(audio.Track.Handle);
            {
                var ms = SDL_mixer.TrackFramesToMS(audio.Track.Handle, frames);
                {
                    return ms;
                }
            }
        }

        public static void SetAudioPlaybackPosition(Audio audio, long ms)
        {
            var frames = SDL_mixer.TrackMSToFrames(audio.Track.Handle, ms);
            {
                SDL_mixer.SetTrackPlaybackPosition(audio.Track.Handle, frames);
            }
        }

        public static long GetAudioPlaybackPosition(Audio audio)
        {
            var frames = SDL_mixer.GetTrackPlaybackPosition(audio.Track.Handle);
            {
                var ms = SDL_mixer.TrackFramesToMS(audio.Track.Handle, frames);
                {
                    return ms;
                }
            }
        }
        
        public static bool AudioPlaying(Audio audio)
        {
            return SDL_mixer.TrackPlaying(audio.Track.Handle);
        }

        public static void PlayAudio(Audio audio)
        {
            SDL_mixer.PlayTrack(audio.Track.Handle, 0);
        }
        
        public static void PauseAudio(Audio audio)
        {
            SDL_mixer.PauseTrack(audio.Track.Handle);
        }

        public static void ResumeAudio(Audio audio)
        {
            SDL_mixer.ResumeTrack(audio.Track.Handle);
        }

        public static void StopAudio(Audio audio, long ms)
        {
            var frames = SDL_mixer.TrackMSToFrames(audio.Track.Handle, ms);
            {
                SDL_mixer.StopTrack(audio.Track.Handle, frames);
            }
        }
    }
}