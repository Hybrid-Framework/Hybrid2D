using static Engine.SDL2.SDL;
using Engine;

namespace App
{
    public class Game : GameBehaviour
    {
        public IntPtr renderer;
        public IntPtr window;
        
        public override void Init(string title, int width, int height, SDL_WindowFlags flags)
        {
            if (SDL_Init(SDL_INIT_VIDEO | SDL_INIT_AUDIO) < 0) throw new Exception($"SDL: {SDL_GetError()}");

            window = SDL_CreateWindow(title, width, height, flags);
            if (window == IntPtr.Zero) throw new Exception($"SDL: {SDL_GetError()}");

            renderer = SDL_CreateRenderer(window, -1, SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC);
            if(renderer == IntPtr.Zero) throw new Exception($"SDL: {SDL_GetError()}");
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
            }
            
            SDL_SetRenderDrawColor(renderer, 255, 128, 128, 255);
            SDL_RenderClear(renderer);
            
            SDL_RenderPresent(renderer);
            return true;
        }
        
        public override void Dispose()
        {
            SDL_DestroyRenderer(renderer);
            SDL_DestroyWindow(window);
            SDL_Quit();
        }
    }
}