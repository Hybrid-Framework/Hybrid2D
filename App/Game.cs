using Hybrid;

namespace App
{
    public class Game : Behaviour
    {
        private IntPtr image;
        
        public override void Init()
        {
            if (!SDL.Init(SDL.InitFlags.Audio | SDL.InitFlags.Video))
            {
                Console.WriteLine("SDL Failed Initialize");
            }
            
            SDL.CreateWindowAndRenderer("Hello World", 600, 400, SDL.WindowFlags.HighPixelDensity);

            image = SDL_image.LoadTexture(FileSystem.LoadAsset("Image.jpg"));
            SDL.SetTextureScaleMode(image, SDL.ScaleMode.Pixel);
            if (image == IntPtr.Zero)
            {
                throw new Exception("Failed to load: " + SDL.GetError());
            }
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
            
            SDL.RenderTexture(image);
            
            SDL.SetRenderDrawColor(0, 0, 0, 255);
            SDL.RenderDebugText(10, 10, "Hello World");
            
            SDL.RenderPresent();
        }
    }
}