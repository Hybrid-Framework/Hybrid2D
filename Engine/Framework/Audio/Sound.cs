using System.IO;
using System;

namespace Hybrid
{
    // Sound
    public sealed unsafe class Sound : SFX
    {
        internal Sound(string path)
        {
            path = Path.Combine(SDL.GetBasePath() + path);
            {
                Handle = SDL_mixer.LoadAudio(Audio.Handle, path, false);

                if (Handle == null)
                {
                    throw new Exception($"Failed to load sound '{path}': {SDL.GetError()}");
                }

                Stereo = new SDL_mixer.StereoGains(1, 1);
                Track = new Track(Handle);
            }
        }
    }
}