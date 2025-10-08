using Hybrid;

namespace App
{
    public class Game : Behaviour
    {
        private SDL.FRect rect = new SDL.FRect()
        {
            x = 0, y = 0, w = 100, h = 100
        };
        
        public override void Init()
        {
            if (!SDL.Init(SDL.InitFlags.Audio | SDL.InitFlags.Video))
            {
                Console.WriteLine("SDL Failed Initialize");
            }
            
            SDL.CreateWindowAndRenderer("Hello World", 600, 400, SDL.WindowFlags.HighPixelDensity);
        }
        
        public override void Update()
        {
            
        }
        
        public override void Render()
        {
            SDL.SetRenderDrawColor(255, 128, 128, 255);
            SDL.RenderClear();
            
            SDL.SetRenderDrawColor(0, 0, 0, 255);
            SDL.RenderDebugText(10, 10, "Hello World");
            
            SDL.SetRenderDrawColor(0, 255, 0, 255);
            SDL.RenderFillRect(rect);
            
            SDL.RenderPresent();
        }
    }
}