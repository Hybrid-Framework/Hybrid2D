using System.IO;
using System;

namespace Hybrid
{
    // Music
    public sealed unsafe class Music : SFX
    {
        internal Music(string path)
        {
            path = Path.Combine(SDL.GetBasePath() + path);
            {
                Handle = SDL_mixer.LoadAudio(Audio.Handle, path, false);

                if (Handle == null)
                {
                    throw new Exception($"Failed to load music '{path}': {SDL.GetError()}");
                }

                Stereo = new SDL_mixer.StereoGains(1, 1);
                Track = new Track(Handle);
            }
        }
    }
}