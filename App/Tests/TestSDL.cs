using Hybrid;
using SDL;

namespace App
{
    public unsafe class TestSDL : Behaviour
    {
        private SDL_Window* window;
        private SDL_Renderer* renderer;
        
        public override void Init()
        {
            if (!SDL3.SDL_Init(SDL_InitFlags.SDL_INIT_VIDEO | SDL_InitFlags.SDL_INIT_VIDEO))
            {
                throw new Exception($"SDL failed to initialize: {SDL3.SDL_GetError()}");
            }

            window = SDL3.SDL_CreateWindow("SDL3", 800, 600, SDL_WindowFlags.SDL_WINDOW_HIGH_PIXEL_DENSITY);
            if (window == null)
            {
                throw new Exception($"SDL failed create window: {SDL3.SDL_GetError()}");
            }

            renderer = SDL3.SDL_CreateRenderer(window, (Utf8String)null);
            if (renderer == null)
            {
                throw new Exception($"SDL failed create renderer: {SDL3.SDL_GetError()}");
            }
        }
        
        public override void Update(SDL_Event @event)
        {
            var e = (SDL_EventType)@event.type;
            Console.WriteLine($"SDL Event: {e}");

            if (e == SDL_EventType.SDL_EVENT_QUIT)
            {
                Platform.Current.IsRunning = false;
                return;
            }
        }
        
        public override void Render()
        {
            SDL3.SDL_SetRenderDrawColor(renderer, 255, 128, 128, 255);
            SDL3.SDL_RenderClear(renderer);

            SDL3.SDL_RenderPresent(renderer);
        }
    }
}