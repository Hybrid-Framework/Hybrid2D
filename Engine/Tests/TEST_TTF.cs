using static Engine.SDL2.SDL_ttf;
using static Engine.SDL2.SDL;
using System;

namespace Engine
{
    public class TEST_TTF : GameBehaviour
    {
        public FPSCounter FPSCounter = new FPSCounter();
        public IntPtr renderer;
        public IntPtr window;
        
        public IntPtr fontTexture;
        public IntPtr font;

        private string teststring = "Testing ttf";
        
        
        public override void Init(string title, int width, int height, SDL_WindowFlags flags)
        {
            if (TTF_Init() < 0) throw new Exception($"SDL TTF: {TTF_GetError()}");
            
            if (SDL_Init(SDL_INIT_VIDEO | SDL_INIT_AUDIO) < 0) throw new Exception($"SDL: {SDL_GetError()}");

            window = SDL_CreateWindow(title, width, height, flags);
            if (window == IntPtr.Zero) throw new Exception($"SDL: {SDL_GetError()}");

            renderer = SDL_CreateRenderer(window, -1, SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC);
            if(renderer == IntPtr.Zero) throw new Exception($"SDL: {SDL_GetError()}");
            
            font = TTF_OpenFont(FileSystem.LoadAsset("Font.ttf"), 24);
            if (font == IntPtr.Zero) throw new Exception($"SDL TTF: {TTF_GetError()}");
            
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
            }
            
            FPSCounter.Update();
            var currentCounter = SDL_GetPerformanceCounter();
            var elapsed = (currentCounter - FPSCounter.startCounter) / (double)FPSCounter.frequency;
            var r = (byte)(Math.Sin(elapsed) * 127 + 128);
            var g = (byte)(Math.Sin(elapsed + Math.PI / 2) * 127 + 128);
            var b = (byte)(Math.Sin(elapsed + Math.PI) * 127 + 128);
            
            SDL_SetRenderDrawColor(renderer, r, g, b, 255);
            SDL_RenderClear(renderer);
            
            IntPtr fontSurface = TTF_RenderText_Solid(font, teststring, new SDL_Color { r = 255, g = 255, b = 255, a = 255 });
            if (fontSurface != IntPtr.Zero)
            {
                fontTexture = SDL_CreateTextureFromSurface(renderer, fontSurface);
                SDL_FreeSurface(fontSurface);
                
                SDL_QueryTexture(fontTexture, out _, out _, out int texW, out int texH);
                SDL_Rect dstRect = new SDL_Rect { x = 10, y = 10, w = texW, h = texH };
                SDL_RenderCopy(renderer, fontTexture, IntPtr.Zero, ref dstRect);
            }
            
            SDL_RenderPresent(renderer);
            SDL_DestroyTexture(fontTexture);
            return true;
        }
        
        public override void Dispose()
        {
            SDL_DestroyRenderer(renderer);
            SDL_DestroyWindow(window);
            TTF_CloseFont(font);
            TTF_Quit();
            SDL_Quit();
        }
    }
}