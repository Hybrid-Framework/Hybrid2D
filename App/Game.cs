using Hybrid;

namespace App
{
    public unsafe class Game : Behaviour
    {
        private IntPtr renderer;
        private IntPtr texture;
        private IntPtr surface;
        private IntPtr window;
        
        public override void Init()
        {
            if (!SDL.Init(SDL.InitFlags.Everything))
            {
                throw new Exception();
            }

            window = SDL.CreateWindow("Hello World", 600, 400, SDL.WindowFlags.HighPixelDensity);
            renderer = SDL.CreateRenderer(window, null);

            texture = SDL_image.LoadTexture(renderer, FileSystem.LoadAsset("Image.png"));
            SDL.SetTextureScaleMode(texture, SDL.ScaleMode.Pixel);
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