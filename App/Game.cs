using Hybrid;

namespace App
{
    public class Game : Behaviour
    {
        public override void Init()
        {
            if (!SDL.Init(SDL.InitFlags.Everything))
            {
                Console.WriteLine("SDL Failed Initialize");
            }
            
            SDL.CreateWindowAndRenderer("Hello World", 1024, 768, SDL.WindowFlags.HighPixelDensity);
        }
        
        public override void Update()
        {
            while (SDL.PollEvent(out var e))
            {
                var type = (SDL.EventType)e.type;
                Console.WriteLine(type);
                
                if (type == SDL.EventType.Quit)
                {
                    Platform.Current.IsRunning = false;
                    return;
                }
            }
        }
        
        public override void Render()
        {
            SDL.SetRenderDrawColor(255, 128, 128, 255);
            SDL.RenderClear();
            
            SDL.RenderPresent();
        }
    }
}