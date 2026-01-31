using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    // Internal
    public sealed unsafe partial class Audio
    {
        internal SDL.IOStream* Stream { get; set; }
        internal SDL.Audio* Handle { get; set; }
        internal GCHandle GCHandle;
        
        internal SDL_mixer.StereoGains Stereo { get; set; }
        internal SDL.Track* Track { get; set; }
        
        
        internal Audio(int hz, float amplitude, long ms)
        {
            Handle = SDL_mixer.CreateSineWaveAudio(Mixer.Handle, hz, amplitude, ms);

            if (Handle == null)
            {
                throw new Exception($"Failed to load audio: {SDL.GetError()}");
            }

            Stereo = new SDL_mixer.StereoGains(1, 1);
            Track = SDL_mixer.CreateTrack(Mixer.Handle);
            SDL_mixer.SetTrackAudio(Track, Handle);
        }
        
        internal Audio(string path)
        {
            // Create Stream
            Stream = Resources.CreateStream(path, out GCHandle);
            {
                // Load Audio From Stream
                Handle = SDL_mixer.LoadAudioIO(Mixer.Handle, Stream, false, false);
                {
                    if (Handle == null)
                    {
                        throw new Exception($"Failed to load audio '{path}': {SDL.GetError()}");
                    }
                }

                // Create & Assign properties
                Stereo = new SDL_mixer.StereoGains(1, 1);
                Track = SDL_mixer.CreateTrack(Mixer.Handle);
                SDL_mixer.SetTrackAudio(Track, Handle);
            }
        }
    }

    // Audio Management
    public unsafe partial class Audio
    {
        // Create new audio sine wave instance
        public static Audio CreateAudio(int hz, float amplitude, long ms)
        {
            return new Audio(hz, amplitude, ms);
        }
        
        // Create new audio instance from file
        public static Audio CreateAudio(string path)
        {
            return new Audio(path);
        }

        // Destroy existing audio instance
        public static void DestroyAudio(Audio audio)
        {
            if (audio.Handle != null)
            {
                SDL_mixer.DestroyAudio(audio.Handle);
                audio.Handle = null;
            }

            if (audio.Track != null)
            {
                SDL_mixer.DestroyTrack(audio.Track);
            }
            
            if (audio.GCHandle.IsAllocated)
            {
                audio.GCHandle.Free();
            }

            if (audio.Stream != null)
            {
                SDL.CloseIO(audio.Stream);
            }
        }
    }
    
    // Master Audio
    public unsafe partial class Audio
    {
        // Set master audio volume
        public static void SetMasterAudioVolume(float volume)
        {
            SDL_mixer.SetMasterGain(Mixer.Handle, volume);
        }
       
        // Get master audio volume
        public static float GetMasterAudioVolume()
        {
            return SDL_mixer.GetMasterGain(Mixer.Handle);
        }
    }

    // Audio
    public unsafe partial class Audio
    {
        // Set audio playback position
        public static void SetAudioPlaybackPosition(Audio audio, long ms)
        {
            var frames = SDL_mixer.TrackMSToFrames(audio.Track, ms);
            {
                SDL_mixer.SetTrackPlaybackPosition(audio.Track, frames);
            }
        }
        
        // Get audio playback position
        public static long GetAudioPlaybackPosition(Audio audio)
        {
            var frames = SDL_mixer.GetTrackPlaybackPosition(audio.Track);
            {
                var ms = SDL_mixer.TrackFramesToMS(audio.Track, frames);
                {
                    return ms;
                }
            }
        }
        
        // Set audio volume
        public static void SetAudioVolume(Audio audio, float volume)
        {
            SDL_mixer.SetTrackGain(audio.Track, Maths.Clamp(volume, 0, 1));
        }
        
        // Get audio volume
        public static float GetAudioVolume(Audio audio)
        {
            return SDL_mixer.GetTrackGain(audio.Track);
        }
        
        // Set audio pitch
        public static void SetAudioPitch(Audio audio, float pitch)
        {
            SDL_mixer.SetTrackFrequencyRatio(audio.Track, pitch);
        }

        // Get audio pitch
        public static float GetAudioPitch(Audio audio)
        {
            return SDL_mixer.GetTrackFrequencyRatio(audio.Track);
        }

        // Set audio pan position (0 left, 0.5 center, 1 right)
        public static void SetAudioPan(Audio audio, float pan)
        {
            pan = Math.Clamp(pan, 0f, 1f);

            float angle = pan * MathF.PI * 0.5f;
            float left  = MathF.Cos(angle);
            float right = MathF.Sin(angle);

            audio.Stereo = new SDL_mixer.StereoGains(left, right);
            SDL_mixer.SetTrackStereo(audio.Track, audio.Stereo);
        }
        
        // Get audio pan position
        public static float GetAudioPan(Audio audio)
        {
            return Math.Clamp(audio.Stereo.right, 0f, 1f);
        }
        
        // Set audio looping
        public static void SetAudioLoop(Audio audio, bool loop)
        {
            SDL_mixer.SetTrackLoops(audio.Track, loop ? -1 : 0);
        }
        
        // Get audio looping
        public static bool GetAudioLoop(Audio audio)
        {
            return SDL_mixer.TrackLooping(audio.Track);
        }
        
        // Get audio remaining time in ms 
        public static long GetAudioRemaining(Audio audio)
        {
            var frames = SDL_mixer.GetTrackRemaining(audio.Track);
            {
                var ms = SDL_mixer.TrackFramesToMS(audio.Track, frames);
                {
                    return ms;
                }
            }
        }
        
        // Get audio duration time in ms
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
        
        // Is audio playing
        public static bool IsAudioPlaying(Audio audio)
        {
            return SDL_mixer.TrackPlaying(audio.Track);
        }

        // Play audio
        public static void PlayAudio(Audio audio)
        {
            SDL_mixer.PlayTrack(audio.Track, 0);
        }
        
        // Pause audio
        public static void PauseAudio(Audio audio)
        {
            SDL_mixer.PauseTrack(audio.Track);
        }

        // Resume audio
        public static void ResumeAudio(Audio audio)
        {
            SDL_mixer.ResumeTrack(audio.Track);
        }

        // Stop audio
        public static void StopAudio(Audio audio)
        {
            var frames = SDL_mixer.TrackMSToFrames(audio.Track, 0);
            {
                SDL_mixer.StopTrack(audio.Track, frames);
            }
        }
        
        // Stop audio with fade in ms
        public static void StopAudio(Audio audio, long ms)
        {
            var frames = SDL_mixer.TrackMSToFrames(audio.Track, ms);
            {
                SDL_mixer.StopTrack(audio.Track, frames);
            }
        }
    }
}