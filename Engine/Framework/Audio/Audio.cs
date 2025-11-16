using System;

namespace Hybrid
{
    // Audio API
    public static unsafe partial class Audio
    {
        public static void Play(Sound sound)
        {
            SDL_mixer.PlayAudio(Engine.AudioDevice.Handle, sound.Handle);
        }
        
        public static float Volume
        {
            get => Engine.AudioDevice.Volume;
            set => Engine.AudioDevice.Volume = value;
        }
    }
}