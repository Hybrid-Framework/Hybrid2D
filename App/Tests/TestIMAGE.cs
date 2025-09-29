using Hybrid;
using SDL;

namespace App
{
    public unsafe class TestIMAGE : Behaviour
    {
        private SDL_Window* window;
        private SDL_Renderer* renderer;
        
        public SDL_Texture* image;
        public SDL_Texture* png;
        public SDL_Texture* bmp;
        public SDL_Texture* jpg;
        private int test = -1;
        
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
            
            png = SDL3_image.IMG_LoadTexture(renderer, FileSystem.LoadAsset("Image.png"));
            if (png == null) throw new Exception($"SDL failed load png: {SDL3.SDL_GetError()}");
            SDL3.SDL_SetTextureScaleMode(png, SDL_ScaleMode.SDL_SCALEMODE_PIXELART);
            
            jpg = SDL3_image.IMG_LoadTexture(renderer, FileSystem.LoadAsset("Image.jpg"));
            if (jpg == null) throw new Exception($"SDL failed load jpg: {SDL3.SDL_GetError()}");
            SDL3.SDL_SetTextureScaleMode(jpg, SDL_ScaleMode.SDL_SCALEMODE_PIXELART);
            
            bmp = SDL3_image.IMG_LoadTexture(renderer, FileSystem.LoadAsset("Image.bmp"));
            if (bmp == null) throw new Exception($"SDL failed load bmp: {SDL3.SDL_GetError()}");
            SDL3.SDL_SetTextureScaleMode(bmp, SDL_ScaleMode.SDL_SCALEMODE_PIXELART);
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
            
            if (e == SDL_EventType.SDL_EVENT_MOUSE_BUTTON_DOWN)
            {
                test++; if (test > 2) test = 0;

                if (test == 0)
                {
                    image = png;
                }
                else if (test == 1)
                {
                    image = jpg;
                }
                else if (test == 2)
                {
                    image = bmp;
                }
            }
        }
        
        public override void Render()
        {
            SDL3.SDL_SetRenderDrawColor(renderer, 255, 128, 128, 255);
            SDL3.SDL_RenderClear(renderer);
            
            // Draw Code Here
            var src = new SDL_FRect() { x = 0, y = 0, w = 800, h = 600};
            var dst = new SDL_FRect() { x = 0, y = 0, w = 800, h = 600};
            SDL3.SDL_RenderTexture(renderer, image, &src, &dst);

            SDL3.SDL_RenderPresent(renderer);
        }
    }
}