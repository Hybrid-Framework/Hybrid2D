using Hybrid;
using SDL3;

namespace App
{
    public class TestIMAGE : Behaviour
    {
        private IntPtr window;
        private IntPtr renderer;
        
        public IntPtr image;
        public IntPtr png;
        public IntPtr bmp;
        public IntPtr jpg;
        private int test = -1;
        
        public override void Init()
        {
            if (!SDL.SDL_Init(SDL.SDL_InitFlags.SDL_INIT_VIDEO | SDL.SDL_InitFlags.SDL_INIT_AUDIO))
            {
                throw new Exception($"SDL failed to initialize: {SDL.SDL_GetError()}");
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
            
            png = IMAGE.IMG_LoadTexture(renderer, FileSystem.LoadAsset("Image.png"));
            if (png == IntPtr.Zero) throw new Exception($"SDL failed load png: {SDL.SDL_GetError()}");
            SDL.SDL_SetTextureScaleMode(png, SDL.SDL_ScaleMode.SDL_SCALEMODE_NEAREST);
            
            jpg = IMAGE.IMG_LoadTexture(renderer, FileSystem.LoadAsset("Image.jpg"));
            if (jpg == IntPtr.Zero) throw new Exception($"SDL failed load jpg: {SDL.SDL_GetError()}");
            SDL.SDL_SetTextureScaleMode(jpg, SDL.SDL_ScaleMode.SDL_SCALEMODE_NEAREST);
            
            bmp = IMAGE.IMG_LoadTexture(renderer, FileSystem.LoadAsset("Image.bmp"));
            if (bmp == IntPtr.Zero) throw new Exception($"SDL failed load bmp: {SDL.SDL_GetError()}");
            SDL.SDL_SetTextureScaleMode(bmp, SDL.SDL_ScaleMode.SDL_SCALEMODE_NEAREST);
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
            
            if (e == SDL.SDL_EventType.SDL_EVENT_MOUSE_BUTTON_DOWN)
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
            SDL.SDL_SetRenderDrawColor(renderer, 255, 128, 128, 255);
            SDL.SDL_RenderClear(renderer);
            
            // Draw Code Here
            var src = new SDL.SDL_FRect() { x = 0, y = 0, w = 800, h = 600};
            var dst = new SDL.SDL_FRect() { x = 0, y = 0, w = 800, h = 600};
            SDL.SDL_RenderTexture(renderer, image, ref src, ref dst);

            SDL.SDL_RenderPresent(renderer);
        }
    }
}