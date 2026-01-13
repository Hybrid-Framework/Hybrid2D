using System;

namespace Hybrid
{
    // Wave
    public sealed unsafe class Wave : SFX
    {
        internal Wave(int hz, float amplitude)
        {
            Handle = SDL_mixer.CreateSineWaveAudio(Audio.Handle, hz, amplitude);

            if (Handle == null)
            {
                throw new Exception($"Failed to create sine wave: {SDL.GetError()}");
            }
            
            Stereo = new SDL_mixer.StereoGains(1, 1);
            Track = new Track(Handle);
        }
    }
}