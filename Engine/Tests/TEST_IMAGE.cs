using static Engine.SDL2.SDL_image;
using static Engine.SDL2.SDL;
using System;

namespace Engine
{
    public class TEST_IMAGE : GameBehaviour
    {
        public FPSCounter FPSCounter = new FPSCounter();
        public IntPtr renderer;
        public IntPtr window;
        
        public IntPtr png;
        public IntPtr bmp;
        public IntPtr jpg;

        public IntPtr testimage = IntPtr.Zero;
        private int test = -1;
        
        
        public override void Init(string title, int width, int height, SDL_WindowFlags flags)
        {
            if (SDL_Init(SDL_INIT_VIDEO | SDL_INIT_AUDIO) < 0) throw new Exception($"SDL: {SDL_GetError()}");
            
            if (IMG_Init(IMG_InitFlags.IMG_INIT_JPG | IMG_InitFlags.IMG_INIT_PNG) < 0) throw new Exception($"SDL IMAGE: {IMG_GetError()}");

            window = SDL_CreateWindow(title, width, height, flags);
            if (window == IntPtr.Zero) throw new Exception($"SDL: {SDL_GetError()}");

            renderer = SDL_CreateRenderer(window, -1, SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC);
            if(renderer == IntPtr.Zero) throw new Exception($"SDL: {SDL_GetError()}");
            
            png = IMG_LoadTexture(renderer, FileSystem.LoadAsset("Image.png"));
            if (png == IntPtr.Zero) throw new Exception($"SDL IMAGE: {IMG_GetError()}");
            
            jpg = IMG_LoadTexture(renderer, FileSystem.LoadAsset("Image.jpg"));
            if (jpg == IntPtr.Zero) throw new Exception($"SDL IMAGE: {IMG_GetError()}");
            
            bmp = IMG_LoadTexture(renderer, FileSystem.LoadAsset("Image.bmp"));
            if (bmp == IntPtr.Zero) throw new Exception($"SDL IMAGE: {IMG_GetError()}");
            
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
                    if (test > 2) test = 0;
                    
                    testimage = IntPtr.Zero;

                    if (test == 0)
                    {
                        testimage = png;
                    }
                    else if (test == 1)
                    {
                        testimage = jpg;
                    }
                    else if (test == 2)
                    {
                        testimage = bmp;
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

            SDL_RenderCopy(renderer, testimage, IntPtr.Zero, IntPtr.Zero);
            
            SDL_RenderPresent(renderer);
            return true;
        }
        
        public override void Dispose()
        {
            SDL_DestroyTexture(testimage);
            SDL_DestroyRenderer(renderer);
            SDL_DestroyWindow(window);
            SDL_DestroyTexture(png);
            SDL_DestroyTexture(jpg);
            SDL_DestroyTexture(bmp);
            IMG_Quit();
            SDL_Quit();
        }
    }
}