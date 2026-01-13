using System.IO;
using System;

namespace Hybrid
{
    // Internal
    public sealed unsafe partial class Sound : Resource
    {
        internal SDL_mixer.StereoGains Stereo { get; set; }
        internal SDL.Audio* Handle { get; set; }
        internal Track Track { get; set; }

        
        internal Sound(string path)
        {
            path = Path.Combine(SDL.GetBasePath() + path);
            {
                Handle = SDL_mixer.LoadAudio(Audio.Mixer.Handle, path, false);

                if (Handle == null)
                {
                    throw new Exception($"Failed to load sound '{path}': {SDL.GetError()}");
                }

                Stereo = new SDL_mixer.StereoGains(1, 1);
                Track = new Track(Handle);
            }
        }

        internal override void Destroy()
        {
            if (Handle != null)
            {
                SDL_mixer.DestroyAudio(Handle);
                Handle = null;
            }

            if (Track != null)
            {
                Track.Destroy();
            }
        }
    }

    // Sound API
    public unsafe partial class Sound
    {
        public void SetPlaybackPosition(long ms)
        {
            var frames = SDL_mixer.TrackMSToFrames(Track.Handle, ms);
            {
                SDL_mixer.SetTrackPlaybackPosition(Track.Handle, frames);
            }
        }
        
        public long GetPlaybackPosition()
        {
            var frames = SDL_mixer.GetTrackPlaybackPosition(Track.Handle);
            {
                var ms = SDL_mixer.TrackFramesToMS(Track.Handle, frames);
                {
                    return ms;
                }
            }
        }
        
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
        
        public void SetVolume(float volume)
        {
            SDL_mixer.SetTrackGain(Track.Handle, Maths.Clamp(volume, 0, 1));
        }
        
        public float GetVolume()
        {
            return SDL_mixer.GetTrackGain(Track.Handle);
        }
        
        public void SetPitch(float pitch)
        {
            SDL_mixer.SetTrackFrequencyRatio(Track.Handle, pitch);
        }

        public float GetPitch()
        {
            return SDL_mixer.GetTrackFrequencyRatio(Track.Handle);
        }

        public void SetPan(float pan)
        {
            pan = Math.Clamp(pan, 0f, 1f);

            float angle = pan * MathF.PI * 0.5f;
            float left  = MathF.Cos(angle);
            float right = MathF.Sin(angle);

            Stereo = new SDL_mixer.StereoGains(left, right);
            SDL_mixer.SetTrackStereo(Track.Handle, Stereo);
        }
        
        public float GetPan()
        {
            return Math.Clamp(Stereo.right, 0f, 1f);
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

        public void Stop(long ms = 0)
        {
            var frames = SDL_mixer.TrackMSToFrames(Track.Handle, ms);
            {
                SDL_mixer.StopTrack(Track.Handle, frames);
            }
        }
        
        public void SetLoop(bool loop)
        {
            SDL_mixer.SetTrackLoops(Track.Handle, loop ? -1 : 0);
        }
        
        public bool GetLoop()
        {
            return SDL_mixer.TrackLooping(Track.Handle);
        }
        
        public bool IsPlaying()
        {
            return SDL_mixer.TrackPlaying(Track.Handle);
        }
    }
}