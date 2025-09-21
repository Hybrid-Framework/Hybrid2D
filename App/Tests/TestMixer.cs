using static Hybrid.SDL2.SDL_mixer;
using static Hybrid.SDL2.SDL;
using Hybrid;

namespace App
{
    public class TestMIXER : Behaviour
    {
        public IntPtr testaudio = IntPtr.Zero;
        private int test = -1;
        public IntPtr mp3;
        public IntPtr wav;
        public IntPtr ogg;

        
        public override void Init()
        {
            Window.CreateWindow("Hybrid", 800, 600);
            
            mp3 = Mix_LoadWAV(FileSystem.LoadAsset("Sound.mp3"));
            if (mp3 == IntPtr.Zero) throw new Exception($"SDL MIXER: {Mix_GetError()}");
            
            wav = Mix_LoadWAV(FileSystem.LoadAsset("Sound.wav"));
            if (wav == IntPtr.Zero) throw new Exception($"SDL MIXER: {Mix_GetError()}");
            
            ogg = Mix_LoadWAV(FileSystem.LoadAsset("Sound.ogg"));
            if (ogg == IntPtr.Zero) throw new Exception($"SDL MIXER: {Mix_GetError()}");
        }

        public override void Events(SDL_Event e)
        {
            if (e.type == SDL_EventType.SDL_QUIT)
            {
                Platform.Current.IsRunning = false;
                return;
            }
            
            if (e.type == SDL_EventType.SDL_MOUSEBUTTONDOWN)
            {
                test++; if (test > 2) test = 0;
                testaudio = IntPtr.Zero;

                if (test == 0)
                {
                    testaudio = mp3;
                    Mix_PlayChannel(-1, testaudio, 0);
                }
                else if (test == 1)
                {
                    testaudio = wav;
                    Mix_PlayChannel(-1, testaudio, 0);
                }
                else if (test == 2)
                {
                    testaudio = ogg;
                    Mix_PlayChannel(-1, testaudio, 0);
                }
            }
        }
        
        public override void Render()
        {
            Graphics.ClearColor(255, 128, 128, 128);
            Graphics.Begin();
            Graphics.End();
        }
    }
}