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
            
            
        }
        
        public override void Update()
        {
            
        }
        
        public override void Render()
        {
            
        }
    }
}