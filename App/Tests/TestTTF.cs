using Hybrid;
using SDL;

namespace App
{
    public unsafe class TestTTF : Behaviour
    {
        private SDL_Window* window;
        private SDL_Renderer* renderer;
        
        private string teststring = "Hello World!";
        public SDL_Texture* fontTexture;
        public TTF_Font* font;
        
        public override void Init()
        {
            if (!SDL3.SDL_Init(SDL_InitFlags.SDL_INIT_VIDEO | SDL_InitFlags.SDL_INIT_VIDEO))
            {
                throw new Exception($"SDL failed to initialize: {SDL3.SDL_GetError()}");
            }

            if (!SDL3_ttf.TTF_Init())
            {
                throw new Exception($"SDL failed to initialize ttf: {SDL3.SDL_GetError()}");
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
            
            font = SDL3_ttf.TTF_OpenFont(FileSystem.LoadAsset("Font.ttf"), 128);
            if (font == null) throw new Exception($"SDL failed to load Font.ttf: {SDL3.SDL_GetError()}");
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
            
            var fontSurface = SDL3_ttf.TTF_RenderText_Solid(font, teststring, 0, new SDL_Color { r = 255, g = 255, b = 255, a = 255 });
            
            if (fontSurface != null)
            {
                fontTexture = SDL3.SDL_CreateTextureFromSurface(renderer, fontSurface);
                SDL3.SDL_DestroySurface(fontSurface);

                float w = 0, h = 0;
                SDL3.SDL_GetTextureSize(fontTexture, &w, &h);
                
                SDL_FRect srcRect = new SDL_FRect { x = 0, y = 0, w = w, h = h };
                SDL_FRect dstRect = new SDL_FRect { x = 0, y = 0, w = w, h = h };
                SDL3.SDL_RenderTexture(renderer, fontTexture, &srcRect, &dstRect);
            }

            SDL3.SDL_RenderPresent(renderer);
            SDL3.SDL_DestroyTexture(fontTexture);
        }
    }
}