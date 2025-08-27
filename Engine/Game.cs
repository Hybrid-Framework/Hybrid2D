using static SDL2.SDL_image;
using static SDL2.SDL_mixer;
using static SDL2.SDL_ttf;
using static SDL2.SDL;
using System;

namespace Engine
{
    public class Game : IDisposable
    {
        public FPSCounter FPSCounter = new FPSCounter();
        public IntPtr renderer;
        public IntPtr window;
        
        public Game(string title, int width, int height, SDL_WindowFlags flags)
        {
            if (TTF_Init() < 0) throw new Exception($"SDL TTF: {TTF_GetError()}");
            
            if (SDL_Init(SDL_INIT_VIDEO | SDL_INIT_AUDIO) < 0) throw new Exception($"SDL: {SDL_GetError()}");
            
            if (IMG_Init(IMG_InitFlags.IMG_INIT_JPG | IMG_InitFlags.IMG_INIT_PNG) < 0) throw new Exception($"SDL IMAGE: {IMG_GetError()}");

            if (Mix_Init(MIX_InitFlags.MIX_INIT_MP3 | MIX_InitFlags.MIX_INIT_OGG) < 0) throw new Exception($"SDL MIXER: {Mix_GetError()}");
            
            if(Mix_OpenAudio(44100, MIX_DEFAULT_FORMAT, 2, 2048) < 0) throw new Exception($"SDL MIXER: {Mix_GetError()}");

            window = SDL_CreateWindow(title, width, height, flags);
            if (window == IntPtr.Zero) throw new Exception($"SDL: {SDL_GetError()}");

            renderer = SDL_CreateRenderer(window, -1, SDL_RendererFlags.SDL_RENDERER_ACCELERATED);
            if(renderer == IntPtr.Zero) throw new Exception($"SDL: {SDL_GetError()}");
            
            FPSCounter.Start();
        }
        
        public bool Update()
        {
            while (SDL_PollEvent(out SDL_Event e) == 1)
            {
                Console.WriteLine($"SDL Event: {e.type}");
                
                if (e.type == SDL_EventType.SDL_QUIT)
                {
                    return false;
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
        
        public void Dispose()
        {
            SDL_DestroyRenderer(renderer);
            SDL_DestroyWindow(window);
            TTF_Quit();
            Mix_Quit();
            IMG_Quit();
            SDL_Quit();
        }
    }
}