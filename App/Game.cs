using Hybrid;

namespace App
{
    public unsafe class Game : Behaviour
    {
        private SDL.Renderer* renderer;
        private SDL.Texture* texture;
        private SDL.Surface* surface;
        private SDL.Window* window;
        
        public override void Init()
        {
            if (!SDL.Init(SDL.InitFlags.Everything))
            {
                throw new Exception();
            }

            window = SDL.CreateWindow("Hello World", 600, 400, SDL.WindowFlags.HighPixelDensity);
            renderer = SDL.CreateRenderer(window, null);

            texture = SDL.CreateTexture(renderer, SDL.PixelFormat.RGBA8888, SDL.TextureAccess.Streaming, 32, 32);
            surface = SDL.CreateSurface(32, 32, SDL.PixelFormat.RGBA8888);
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

            SDL.RenderPresent(renderer);
        }
    }
}