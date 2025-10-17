using Hybrid;

namespace App
{
    public unsafe class Game : Behaviour
    {
        private IntPtr renderer;
        private IntPtr texture;
        private IntPtr window;
        private IntPtr track;
        private IntPtr mixer;
        private IntPtr sound;
        private IntPtr font;
        private IntPtr fontSurface;
        private IntPtr fontTexture;
        
        public override void Init()
        {
            // Init
            if (!SDL.Init(SDL.InitFlags.Everything)) throw new Exception(SDL.GetError());
            if (!SDL_image.Init()) throw new Exception(SDL.GetError());
            if (!SDL_mixer.Init()) throw new Exception(SDL.GetError());
            if (!SDL_ttf.Init()) throw new Exception(SDL.GetError());
            
            // Window
            window = SDL.CreateWindow("Hybrid", 600, 400, SDL.WindowFlags.HighPixelDensity);
            renderer = SDL.CreateRenderer(window, null);
            
            // Texture
            texture = SDL_image.LoadTexture(renderer, FileSystem.LoadAsset("Image.png"));
            SDL.SetTextureScaleMode(texture, SDL.ScaleMode.Pixel);
            
            // Font
            font = SDL_ttf.OpenFont(FileSystem.LoadAsset("Font.ttf"), 24);
            fontSurface = SDL_ttf.RenderTextSolid(font, "Hello World", new SDL.Color() { r = 255, g = 255, b = 255, a = 255 });
            fontTexture = SDL.CreateTextureFromSurface(renderer, fontSurface);
            SDL.DestroySurface(fontSurface); 
            
            // Sound
            mixer = SDL_mixer.CreateMixerDevice(SDL.DefaultPlaybackDevice, new SDL.AudioSpec());
            sound = SDL_mixer.LoadAudio(mixer, FileSystem.LoadAsset("Sound.mp3"), false);
            track = SDL_mixer.CreateTrack(mixer);
            SDL_mixer.SetTrackAudio(track, sound);
            SDL_mixer.PlayTrack(track, 0);
            
            // Platform
            Console.WriteLine("Platform: " + SDL.GetPlatform());
            
            // Texture Test
            var test = SDL.CreateTexture(renderer, SDL.PixelFormat.RGBA8888, SDL.TextureAccess.Streaming, 16, 16);
            if (test == IntPtr.Zero) throw new Exception("Texture failed");
        }
        
        public override void Update()
        {
            // Input
            while (SDL.PollEvent(out SDL.Event e))
            {
                var type = (SDL.EventType)e.type;
                Console.WriteLine("Event: " + type);

                if (type == SDL.EventType.Quit)
                {
                    Platform.Current.IsRunning = false;
                    return;
                }
            }
        }
        
        public override void Render()
        {
            // Render
            SDL.SetRenderDrawColor(renderer, 255, 128, 128, 255);
            SDL.RenderClear(renderer);

            // Texture
            SDL.RenderTexture(renderer, texture, null, null);
            
            // Font
            int width = SDL.GetTextureWidth(fontTexture);
            int height = SDL.GetTextureHeight(fontTexture);
            SDL.FRect rect = new SDL.FRect() { x = 10, y = 0, w = width, h = height };
            SDL.RenderTexture(renderer, fontTexture, null, rect);
            
            // Debug Text
            SDL.SetRenderDrawColor(renderer, 255, 255, 255, 255);
            SDL.RenderDebugText(renderer, 10, 40, "Debug Text");
            
            // Present
            SDL.RenderPresent(renderer);
        }
    }
}