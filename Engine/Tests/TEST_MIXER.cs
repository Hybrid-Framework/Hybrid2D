using static Engine.Internal.SDL2.SDL_mixer;
using static Engine.Internal.SDL2.SDL;
using System;

namespace Engine
{
    public class TEST_MIXER : GameBehaviour
    {
        public FPSCounter FPSCounter = new FPSCounter();
        public IntPtr renderer;
        public IntPtr window;
        
        public IntPtr mp3;
        public IntPtr wav;
        public IntPtr ogg;

        public IntPtr testaudio = IntPtr.Zero;
        private int test = -1;
        
        
        public override void Init(string title, int width, int height, SDL_WindowFlags flags)
        {
            if (SDL_Init(SDL_INIT_VIDEO | SDL_INIT_AUDIO) < 0) throw new Exception($"SDL: {SDL_GetError()}");
            
            if (Mix_Init(MIX_InitFlags.MIX_INIT_MP3 | MIX_InitFlags.MIX_INIT_OGG) < 0) throw new Exception($"SDL MIXER: {Mix_GetError()}");
            
            if(Mix_OpenAudio(44100, MIX_DEFAULT_FORMAT, 2, 2048) < 0) throw new Exception($"SDL MIXER: {Mix_GetError()}");

            window = SDL_CreateWindow(title, width, height, flags);
            if (window == IntPtr.Zero) throw new Exception($"SDL: {SDL_GetError()}");

            renderer = SDL_CreateRenderer(window, -1, SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC);
            if(renderer == IntPtr.Zero) throw new Exception($"SDL: {SDL_GetError()}");
            
            mp3 = Mix_LoadWAV(FileSystem.LoadAsset("Sound.mp3"));
            if (mp3 == IntPtr.Zero) throw new Exception($"SDL MIXER: {Mix_GetError()}");
            
            wav = Mix_LoadWAV(FileSystem.LoadAsset("Sound.wav"));
            if (wav == IntPtr.Zero) throw new Exception($"SDL MIXER: {Mix_GetError()}");
            
            ogg = Mix_LoadWAV(FileSystem.LoadAsset("Sound.ogg"));
            if (ogg == IntPtr.Zero) throw new Exception($"SDL MIXER: {Mix_GetError()}");
            
            FPSCounter.Start();
        }
        
        public override bool Update()
        {
            while (SDL_PollEvent(out SDL_Event e) == 1)
            {
                Console.WriteLine($"SDL Event: {e.type}");
                
                if (e.type == SDL_EventType.SDL_QUIT)
                {
                    return false;
                }

                if (e.type == SDL_EventType.SDL_MOUSEBUTTONDOWN)
                {
                    test++;
                    if (test > 3) test = 0;
                    
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
            
            FPSCounter.Update();
            var currentCounter = SDL_GetPerformanceCounter();
            var elapsed = (currentCounter - FPSCounter.startCounter) / (double)FPSCounter.frequency;
            var r = (byte)(Math.Sin(elapsed) * 127 + 128);
            var g = (byte)(Math.Sin(elapsed + Math.PI / 2) * 127 + 128);
            var b = (byte)(Math.Sin(elapsed + Math.PI) * 127 + 128);
            
            SDL_SetRenderDrawColor(renderer, r, g, b, 255);
            SDL_RenderClear(renderer);
            
            SDL_RenderPresent(renderer);
            return true;
        }
        
        public override void Dispose()
        {
            Mix_FreeChunk(testaudio);
            SDL_DestroyRenderer(renderer);
            SDL_DestroyWindow(window);
            Mix_FreeChunk(mp3);
            Mix_FreeChunk(wav);
            Mix_FreeChunk(ogg);
            Mix_Quit();
            SDL_Quit();
        }
    }
}