using Hybrid;

namespace App
{
    public unsafe class Game : Behaviour
    {
        private IntPtr renderer;
        private IntPtr texture;
        private IntPtr surface;
        private IntPtr window;
        private IntPtr track;
        private IntPtr mixer;
        private IntPtr sound;
        
        public override void Init()
        {
            if (!SDL.Init(SDL.InitFlags.Everything))
            {
                throw new Exception(SDL.GetError());
            }

            if (!SDL_image.Init())
            {
                throw new Exception(SDL.GetError());
            }

            if (!SDL_mixer.Init())
            {
                throw new Exception(SDL.GetError());
            }

            window = SDL.CreateWindow("Hello World", 600, 400, SDL.WindowFlags.HighPixelDensity);
            renderer = SDL.CreateRenderer(window, null);

            texture = SDL_image.LoadTexture(renderer, FileSystem.LoadAsset("Image.png"));
            SDL.SetTextureScaleMode(texture, SDL.ScaleMode.Pixel);

            mixer = SDL_mixer.CreateMixerDevice(SDL.DefaultPlaybackDevice, new SDL.AudioSpec());
            sound = SDL_mixer.LoadAudio(mixer, FileSystem.LoadAsset("Sound.mp3"), false);
            track = SDL_mixer.CreateTrack(mixer);
            
            SDL_mixer.SetTrackAudio(track, sound);
            SDL_mixer.PlayTrack(track, 0);
        }
        
        public override void Update()
        {
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
            SDL.SetRenderDrawColor(renderer, 255, 128, 128, 255);
            SDL.RenderClear(renderer);

            SDL.RenderTexture(renderer, texture, null, null);

            SDL.RenderPresent(renderer);
        }
    }
}