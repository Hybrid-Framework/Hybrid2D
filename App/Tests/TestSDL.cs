using Hybrid;
using SDL3;

namespace App
{
    public class TestSDL : Behaviour
    {
        private IntPtr window;
        private IntPtr renderer;
        
        public override void Init()
        {
            if (!SDL.SDL_Init(SDL.SDL_InitFlags.SDL_INIT_VIDEO | SDL.SDL_InitFlags.SDL_INIT_VIDEO))
            {
                throw new Exception($"SDL failed to initialize: {SDL.SDL_GetError()}");
            }

            window = SDL.SDL_CreateWindow("SDL3", 800, 600, SDL.SDL_WindowFlags.SDL_WINDOW_HIGH_PIXEL_DENSITY);
            if (window == IntPtr.Zero)
            {
                throw new Exception($"SDL failed create window: {SDL.SDL_GetError()}");
            }

            renderer = SDL.SDL_CreateRenderer(window, null);
            if (renderer == IntPtr.Zero)
            {
                throw new Exception($"SDL failed create renderer: {SDL.SDL_GetError()}");
            }
        }
        
        public override void Update(SDL.SDL_Event @event)
        {
            var e = (SDL.SDL_EventType)@event.type;
            Console.WriteLine($"SDL Event: {e}");

            if (e == SDL.SDL_EventType.SDL_EVENT_QUIT)
            {
                Platform.Current.IsRunning = false;
                return;
            }
        }
        
        public override void Render()
        {
            SDL.SDL_SetRenderDrawColor(renderer, 255, 128, 128, 255);
            SDL.SDL_RenderClear(renderer);

            SDL.SDL_RenderPresent(renderer);
        }
    }
}