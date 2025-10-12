using Hybrid;

namespace App
{
    public unsafe class Game : Behaviour
    {
        public SDL.Window* window;
        
        public override void Init()
        {
            if(!SDL.Init(SDL.InitFlags.Everything))
            {
                throw new Exception();
            }

            window = SDL.CreateWindow("Hello", 600, 400, SDL.WindowFlags.HighPixelDensity);
        }
        
        public override void Update()
        {
            
        }
        
        public override void Render()
        {
            
        }
    }
}