using Hybrid;
using SDL3;

namespace App
{
    public class TestTTF : Behaviour
    {
        private IntPtr window;
        private IntPtr renderer;
        
        private string teststring = "Hello World!";
        public IntPtr fontTexture;
        public IntPtr font;
        
        public override void Init()
        {
            if (!SDL.SDL_Init(SDL.SDL_InitFlags.SDL_INIT_VIDEO | SDL.SDL_InitFlags.SDL_INIT_AUDIO))
            {
                throw new Exception($"SDL failed to initialize: {SDL.SDL_GetError()}");
            }
            
            if (!TTF.TTF_Init())
            {
                throw new Exception($"SDL failed to initialize ttf: {SDL.SDL_GetError()}");
            }

            window = SDL.SDL_CreateWindow("SDL3", 800, 600, SDL.SDL_WindowFlags.SDL_WINDOW_HIGH_PIXEL_DENSITY | SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE);
            if (window == IntPtr.Zero)
            {
                throw new Exception($"SDL failed create window: {SDL.SDL_GetError()}");
            }

            renderer = SDL.SDL_CreateRenderer(window, null);
            if (renderer == IntPtr.Zero)
            {
                throw new Exception($"SDL failed create renderer: {SDL.SDL_GetError()}");
            }
            
            font = TTF.TTF_OpenFont(FileSystem.LoadAsset("Font.ttf"), 128);
            if (font == IntPtr.Zero) throw new Exception($"SDL failed to load Font.ttf: {SDL.SDL_GetError()}");
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
            
            var fontSurface = TTF.TTF_RenderText_Solid(font, teststring, 0, new SDL.SDL_Color { r = 255, g = 255, b = 255, a = 255 });
            
            if (fontSurface != IntPtr.Zero)
            {
                fontTexture = SDL.SDL_CreateTextureFromSurface(renderer, fontSurface);
                SDL.SDL_DestroySurface(fontSurface);

                SDL.SDL_GetTextureSize(fontTexture, out var w, out var h);
                
                SDL.SDL_FRect srcRect = new SDL.SDL_FRect { x = 0, y = 0, w = w, h = h };
                SDL.SDL_FRect dstRect = new SDL.SDL_FRect { x = 20, y = 20, w = w, h = h };
                SDL.SDL_RenderTexture(renderer, fontTexture, ref srcRect, ref dstRect);
            }

            SDL.SDL_RenderPresent(renderer);
            SDL.SDL_DestroyTexture(fontTexture);
        }
    }
}