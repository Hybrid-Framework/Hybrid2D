using System.Collections.Generic;
using System;

namespace Hybrid
{
    // Internal
    public sealed unsafe partial class Audio : Module
    {
        internal static Mixer Mixer
        {
            get; private set;
        }

        // Constructor
        internal Audio()
        {
            
        }

        // Initialize
        internal override void OnInitialize()
        {
            Mixer = new Mixer();
        }
        
        // Dispose
        internal override void OnDispose()
        {
            if (Mixer != null)
            {
                Mixer.Destroy();
            }
        }
    }

    // Management API
    public unsafe partial class Audio
    {
        public static Sound CreateSound(string path)
        {
            return new Sound(path);
        }

        public static void DestroySound(Sound sound)
        {
            sound?.Destroy();
        }
    }

    // Master API
    public unsafe partial class Audio
    {
        public static void SetMasterVolume(float volume)
        {
            SDL_mixer.SetMasterGain(Mixer.Handle, volume);
        }

        public static float GetMasterVolume()
        {
            return SDL_mixer.GetMasterGain(Mixer.Handle);
        }
    }
    
    // Sound API
    public unsafe partial class Audio
    {
        public static void SetSoundPlaybackPosition(Sound sound, long ms)
        {
            sound.SetPlaybackPosition(ms);
        }

        public static long GetSoundPlaybackPosition(Sound sound)
        {
            return sound.GetPlaybackPosition();
        }

        public static long GetSoundRemaining(Sound sound)
        {
            return sound.GetRemaining();
        }

        public static long GetSoundDuration(Sound sound)
        {
            return sound.GetDuration();
        }

        public static void SetSoundVolume(Sound sound, float volume)
        {
            sound.SetVolume(volume);
        }

        public static float GetSoundVolume(Sound sound)
        {
            return sound.GetVolume();
        }
        
        public static void SetSoundPitch(Sound sound, float pitch)
        {
            sound.SetPitch(pitch);
        }

        public static float GetSoundPitch(Sound sound)
        {
            return sound.GetPitch();
        }
        
        public static void SetSoundPan(Sound sound, float pan)
        {
            sound.SetPan(pan);
        }

        public static float GetSoundPan(Sound sound)
        {
            return sound.GetPan();
        }
        
        public static void SetSoundLooping(Sound sound, bool loop)
        {
            sound.SetLoop(loop);
        }

        public static void GetSoundLooping(Sound sound)
        {
            sound.GetLoop();
        }

        public static bool IsSoundPlaying(Sound sound)
        {
            return sound.IsPlaying();
        }
        
        public static void PlaySound(Sound sound)
        {
            sound.Play();
        }
        
        public static void PauseSound(Sound sound)
        {
            sound.Pause();
        }
        
        public static void ResumeSound(Sound sound)
        {
            sound.Resume();
        }
        
        public static void StopSound(Sound sound, long ms)
        {
            sound.Stop(ms);
        }
    }
}