using static Engine.Internal.SDL2.SDL_image;
using static Engine.Internal.SDL2.SDL_mixer;
using static Engine.Internal.SDL2.SDL_ttf;
using static Engine.Internal.SDL2.SDL;
using System;

namespace Engine
{
    public class Game2 : Game
    {
        public FPSCounter FPSCounter = new FPSCounter();
        public IntPtr renderer;
        public IntPtr window;
        
        public IntPtr fontTexture;
        public IntPtr font;
        public IntPtr png;
        public IntPtr bmp;
        public IntPtr jpg;
        public IntPtr mp3;
        public IntPtr wav;
        public IntPtr ogg;

        private string teststring = "Touch to switch test";
        public IntPtr testaudio = IntPtr.Zero;
        public IntPtr testimage= IntPtr.Zero;
        private int test = -1;
        
        
        public override void Init(string title, int width, int height, SDL_WindowFlags flags)
        {
            if (TTF_Init() < 0) throw new Exception($"SDL TTF: {TTF_GetError()}");
            
            if (SDL_Init(SDL_INIT_VIDEO | SDL_INIT_AUDIO) < 0) throw new Exception($"SDL: {SDL_GetError()}");
            
            if (IMG_Init(IMG_InitFlags.IMG_INIT_JPG | IMG_InitFlags.IMG_INIT_PNG) < 0) throw new Exception($"SDL IMAGE: {IMG_GetError()}");

            if (Mix_Init(MIX_InitFlags.MIX_INIT_MP3 | MIX_InitFlags.MIX_INIT_OGG) < 0) throw new Exception($"SDL MIXER: {Mix_GetError()}");
            
            if(Mix_OpenAudio(44100, MIX_DEFAULT_FORMAT, 2, 2048) < 0) throw new Exception($"SDL MIXER: {Mix_GetError()}");

            window = SDL_CreateWindow(title, width, height, flags);
            if (window == IntPtr.Zero) throw new Exception($"SDL: {SDL_GetError()}");

            renderer = SDL_CreateRenderer(window, -1, SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC);
            if(renderer == IntPtr.Zero) throw new Exception($"SDL: {SDL_GetError()}");
            
            LoadAssetFiles();
        }

        public void LoadAssetFiles()
        {
            FPSCounter.Start();
            
            font = TTF_OpenFont(FileSystem.LoadAsset("Font.ttf"), 24);
            if (font == IntPtr.Zero) throw new Exception($"SDL TTF: {TTF_GetError()}");
            
            png = IMG_LoadTexture(renderer, FileSystem.LoadAsset("Image.png"));
            if (png == IntPtr.Zero) throw new Exception($"SDL IMAGE: {IMG_GetError()}");
            
            jpg = IMG_LoadTexture(renderer, FileSystem.LoadAsset("Image.jpg"));
            if (jpg == IntPtr.Zero) throw new Exception($"SDL IMAGE: {IMG_GetError()}");
            
            bmp = IMG_LoadTexture(renderer, FileSystem.LoadAsset("Image.bmp"));
            if (bmp == IntPtr.Zero) throw new Exception($"SDL IMAGE: {IMG_GetError()}");
            
            mp3 = Mix_LoadWAV(FileSystem.LoadAsset("Sound.mp3"));
            if (mp3 == IntPtr.Zero) throw new Exception($"SDL MIXER: {Mix_GetError()}");
            
            wav = Mix_LoadWAV(FileSystem.LoadAsset("Sound.wav"));
            if (wav == IntPtr.Zero) throw new Exception($"SDL MIXER: {Mix_GetError()}");
            
            ogg = Mix_LoadWAV(FileSystem.LoadAsset("Sound.ogg"));
            if (ogg == IntPtr.Zero) throw new Exception($"SDL MIXER: {Mix_GetError()}");
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
                    if (test > 5) test = 0;
                    
                    testimage = IntPtr.Zero;
                    testaudio = IntPtr.Zero;

                    if (test == 0)
                    {
                        teststring = "Test (mp3)";
                        testaudio = mp3;
                            
                        Mix_PlayChannel(-1, testaudio, 0);
                    }
                    else if (test == 1)
                    {
                        teststring = "Test (wav)";
                        testaudio = wav;
                            
                        Mix_PlayChannel(-1, testaudio, 0);
                    }
                    else if (test == 2)
                    {
                        teststring = "Test (ogg)";
                        testaudio = ogg;
                            
                        Mix_PlayChannel(-1, testaudio, 0);
                    }
                    else if (test == 3)
                    {
                        teststring = "Test (png)";
                        testimage = png;
                    }
                    else if (test == 4)
                    {
                        teststring = "Test (jpg)";
                        testimage = jpg;
                    }
                    else if (test == 5)
                    {
                        teststring = "Test (bmp)";
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
            SDL_DestroyTexture(testimage);
            Mix_FreeChunk(testaudio);
            
            SDL_DestroyRenderer(renderer);
            SDL_DestroyWindow(window);
            SDL_DestroyTexture(png);
            SDL_DestroyTexture(jpg);
            SDL_DestroyTexture(bmp);
            TTF_CloseFont(font);
            Mix_FreeChunk(mp3);
            Mix_FreeChunk(wav);
            Mix_FreeChunk(ogg);
            TTF_Quit();
            Mix_Quit();
            IMG_Quit();
            SDL_Quit();
        }
    }
}