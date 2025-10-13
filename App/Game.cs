using Hybrid;

namespace App
{
    public unsafe class Game : Behaviour
    {
        private SDL.Window* window;
        private SDL.Renderer* renderer;
        private SDL.Texture* texture;
        private SDL.Surface* surface;
        
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
            
            Console.WriteLine($"Base: {SDL.GetBasePath()}");
            Console.WriteLine($"System: {SDL.GetUserFolder(SDL.SystemFolder.Desktop)}");
        }
        
        public override void Update()
        {
            
        }
        
        public override void Render()
        {
            
        }
    }
}