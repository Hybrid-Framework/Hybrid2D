using System;

namespace Hybrid
{
    public static unsafe class Audio
    {
        internal static AudioListener AudioListener = new AudioListener();

        public static void Play(AudioClip audioClip)
        {
            SDL_mixer.PlayAudio(AudioListener.Handle, audioClip.Handle);
        }
    }
}