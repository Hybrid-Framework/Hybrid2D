using Hybrid;

namespace App
{
    public class Game : Behaviour
    {
        public override void Init()
        {
            if (!SDL.Init(SDL.InitFlags.Audio | SDL.InitFlags.Video))
            {
                Console.WriteLine("SDL Failed Initialize");
            }

            var window = SDL.CreateWindow("Hello World", 600, 400, SDL.WindowFlags.HighPixelDensity);
            SDL.SetWindowTitle("My Window");
        }
        
        public override void Update()
        {
            
        }
        
        public override void Render()
        {
            
        }
    }
}