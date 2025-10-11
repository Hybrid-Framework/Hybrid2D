using Hybrid;

namespace App
{
    public class Game : Behaviour
    {
        private SDL.FRect rect = new SDL.FRect()
        {
            x = 0, y = 0, w = 128, h = 128
        };
        
        private IntPtr texture;
        
        public override void Init()
        {
            if (!SDL.Init(SDL.InitFlags.Everything))
            {
                Console.WriteLine("SDL Failed Initialize");
            }
            
            SDL.CreateWindowAndRenderer("Hello World", 1024, 768, SDL.WindowFlags.HighPixelDensity);
            
            int texWidth = 16, texHeight = 16;
            texture = SDL.CreateTexture(
                SDL.PixelFormat.RGBA8888,
                SDL.TextureAccess.Streaming,
                texWidth,
                texHeight
            );

            SDL.SetTextureScaleMode(texture, SDL.ScaleMode.Pixel);
            
            SDL.Pixel[] pixels = new SDL.Pixel[texWidth * texHeight];
            int idx = 0;
            for (int y = 0; y < texHeight; y++)
            {
                for (int x = 0; x < texWidth; x++)
                {
                    pixels[idx++] = new SDL.Pixel
                    {
                        x = x,
                        y = y,
                        r = 255,
                        g = 255,
                        b = 255,
                        a = 255
                    };
                }
            }
            
            SDL.SetTexturePixels(texture, pixels);
            SDL.SetTexturePixel(texture, new SDL.Pixel() { x = 0, y = 0, r = 0, g = 0, b = 0, a = 255});
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
            
            SDL.RenderTexture(texture, rect, rect);
            
            SDL.RenderPresent();
        }
    }
}