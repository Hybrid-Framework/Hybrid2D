using System.Collections.Generic;
using System;

namespace Hybrid
{
    // Internal
    public sealed unsafe partial class Audio : Module
    {
        internal Audio() { }
        
        internal static List<Sound> AllSound { get; private set; } = new List<Sound>();
        internal static List<Music> AllMusic { get; private set; } = new List<Music>();
        internal static List<Wave> AllWave { get; private set; } = new List<Wave>();
        
        internal static SDL.Mixer* Handle
        {
            get; set;
        }

        // Initialize
        internal override void OnInitialize()
        {
            Handle = SDL_mixer.CreateMixerDevice(SDL.DefaultPlaybackDevice, new SDL.AudioSpec()
            {
                format = SDL.AudioFormat.S32,
                channels = 2,
                freq = 44100
            });
        }
        
        // Dispose
        internal override void Destroy()
        {
            foreach(var sound in AllSound) sound.Destroy();
            foreach(var music in AllMusic) music.Destroy();
            foreach(var wave in AllWave) wave.Destroy();
            
            if (Handle != null)
            {
                SDL_mixer.DestroyMixer(Handle);
                Handle = null;
            }
        }
    }

    // Management API
    public partial class Audio
    {
        public static Sound CreateSound(string path)
        {
            var sound = new Sound(path);
            AllSound.Add(sound);
            return sound;
        }

        public static void DestroySound(Sound sound)
        {
            AllSound.Remove(sound);
            sound.Destroy();
        }
        
        public static Music CreateMusic(string path)
        {
            var music = new Music(path);
            AllMusic.Add(music);
            return music;
        }

        public static void DestroyMusic(Music music)
        {
            AllMusic.Remove(music);
            music.Destroy();
        }
        
        public static Wave CreateWave(int hz, float amplitude)
        {
            var wave = new Wave(hz, amplitude);
            AllWave.Add(wave);
            return wave;
        }

        public static void DestroyWave(Wave wave)
        {
            AllWave.Remove(wave);
            wave.Destroy();
        }
    }

    // Master API
    public unsafe partial class Audio
    {
        public static void SetMasterVolume(float volume)
        {
            SDL_mixer.SetMasterGain(Handle, volume);
        }

        public static float GetMasterVolume()
        {
            return SDL_mixer.GetMasterGain(Handle);
        }
    }
    
    // Sound API
    public partial class Audio
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
    
    // Music API
    public partial class Audio
    {
        public static void SetMusicPlaybackPosition(Music music, long ms)
        {
            music.SetPlaybackPosition(ms);
        }

        public static long GetMusicPlaybackPosition(Music music)
        {
            return music.GetPlaybackPosition();
        }

        public static long GetMusicRemaining(Music music)
        {
            return music.GetRemaining();
        }

        public static long GetMusicDuration(Music music)
        {
            return music.GetDuration();
        }

        public static void SetMusicVolume(Music music, float volume)
        {
            music.SetVolume(volume);
        }

        public static float GetMusicVolume(Music music)
        {
            return music.GetVolume();
        }
        
        public static void SetMusicPitch(Music music, float pitch)
        {
            music.SetPitch(pitch);
        }

        public static float GetMusicPitch(Music music)
        {
            return music.GetPitch();
        }
        
        public static void SetMusicPan(Music music, float pan)
        {
            music.SetPan(pan);
        }

        public static float GetMusicPan(Music music)
        {
            return music.GetPan();
        }
        
        public static void SetMusicLooping(Music music, bool loop)
        {
            music.SetLoop(loop);
        }

        public static void GetMusicLooping(Music music)
        {
            music.GetLoop();
        }

        public static bool IsMusicPlaying(Music music)
        {
            return music.IsPlaying();
        }
        
        public static void PlayMusic(Music music)
        {
            music.Play();
        }
        
        public static void PauseMusic(Music music)
        {
            music.Pause();
        }
        
        public static void ResumeMusic(Music music)
        {
            music.Resume();
        }
        
        public static void StopMusic(Music music, long ms)
        {
            music.Stop(ms);
        }
    }
    
    // Wave API
    public partial class Audio
    {
        public static void SetWavePlaybackPosition(Wave wave, long ms)
        {
            wave.SetPlaybackPosition(ms);
        }

        public static long GetWavePlaybackPosition(Wave wave)
        {
            return wave.GetPlaybackPosition();
        }

        public static long GetWaveRemaining(Wave wave)
        {
            return wave.GetRemaining();
        }

        public static long GetWaveDuration(Wave wave)
        {
            return wave.GetDuration();
        }

        public static void SetWaveVolume(Wave wave, float volume)
        {
            wave.SetVolume(volume);
        }

        public static float GetWaveVolume(Wave wave)
        {
            return wave.GetVolume();
        }
        
        public static void SetWavePitch(Wave wave, float pitch)
        {
            wave.SetPitch(pitch);
        }

        public static float GetWavePitch(Wave wave)
        {
            return wave.GetPitch();
        }
        
        public static void SetWavePan(Wave wave, float pan)
        {
            wave.SetPan(pan);
        }

        public static float GetWavePan(Wave wave)
        {
            return wave.GetPan();
        }
        
        public static void SetWaveLooping(Wave wave, bool loop)
        {
            wave.SetLoop(loop);
        }

        public static void GetWaveLooping(Wave wave)
        {
            wave.GetLoop();
        }

        public static bool IsWavePlaying(Wave wave)
        {
            return wave.IsPlaying();
        }
        
        public static void PlayWave(Wave wave)
        {
            wave.Play();
        }
        
        public static void PauseWave(Wave wave)
        {
            wave.Pause();
        }
        
        public static void ResumeWave(Wave wave)
        {
            wave.Resume();
        }
        
        public static void StopWave(Wave wave, long ms)
        {
            wave.Stop(ms);
        }
    }
}