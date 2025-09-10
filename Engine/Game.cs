using static Engine.Internal.SDL2.SDL;
using System;

namespace Engine
{
    public class Game : IDisposable
    {
        public FPSCounter FPSCounter = new FPSCounter();
        public IntPtr renderer;
        public IntPtr window;
        public IntPtr texutre;
        
        public void Init(string title, int width, int height, SDL_WindowFlags flags)
        {
            Environment.SetEnvironmentVariable("SDL_VIDEODRIVER", "x11");

            Console.WriteLine($"DISPLAY={Environment.GetEnvironmentVariable("DISPLAY")}");
            Console.WriteLine($"SDL_VIDEODRIVER={Environment.GetEnvironmentVariable("SDL_VIDEODRIVER")}");

            if (SDL_Init(SDL_INIT_VIDEO) < 0) throw new Exception($"SDL: {SDL_GetError()}");

            Console.WriteLine($"DISPLAY={Environment.GetEnvironmentVariable("DISPLAY")}");
            Console.WriteLine($"SDL_VIDEODRIVER={Environment.GetEnvironmentVariable("SDL_VIDEODRIVER")}");

            
            
            
            window = SDL_CreateWindow(title, width, height, flags);
            if (window == IntPtr.Zero) throw new Exception($"SDL: {SDL_GetError()}");

            renderer = SDL_CreateRenderer(window, -1, SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC);
            if (renderer == IntPtr.Zero) throw new Exception($"SDL: {SDL_GetError()}");
            
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
            SDL_DestroyTexture(texutre);
            SDL_DestroyWindow(window);
            SDL_Quit();
        }
    }
}