using Hybrid;

namespace App
{
    public unsafe class Game : Behaviour
    {
        public override void Init()
        {
            if (!SDL.Init(SDL.InitFlags.Everything))
            {
                throw new Exception(SDL.GetError());
            }

            var window = SDL.CreateWindow("title", 600, 400, SDL.WindowFlags.HighPixelDensity);
            var renderer = SDL.CreateRenderer(window, null);

            SDL.Rect rect = new SDL.Rect();
            SDL.SetRenderClipRect(renderer, rect);
        }
        
        public override void Update()
        {
            
        }
        
        public override void Render()
        {
            
        }
    }
}