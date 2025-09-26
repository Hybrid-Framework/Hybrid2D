using static Hybrid.SDL2.SDL_image;
using static Hybrid.SDL2.SDL;
using Hybrid;

namespace App
{
    public class TestIMAGE : Behaviour
    {
        public IntPtr testimage = IntPtr.Zero;
        private int test = -1;
        public IntPtr png;
        public IntPtr bmp;
        public IntPtr jpg;
        public IntPtr webp;

        
        public override void Init()
        {
            Window.CreateWindow("Hybrid", 800, 600);
            
            png = IMG_LoadTexture(Window.GetRenderer(), FileSystem.LoadAsset("Image.png"));
            if (png == IntPtr.Zero) throw new Exception($"SDL IMAGE: {IMG_GetError()}");
            
            jpg = IMG_LoadTexture(Window.GetRenderer(), FileSystem.LoadAsset("Image.jpg"));
            if (jpg == IntPtr.Zero) throw new Exception($"SDL IMAGE: {IMG_GetError()}");
            
            bmp = IMG_LoadTexture(Window.GetRenderer(), FileSystem.LoadAsset("Image.bmp"));
            if (bmp == IntPtr.Zero) throw new Exception($"SDL IMAGE: {IMG_GetError()}");
            
            webp = IMG_LoadTexture(Window.GetRenderer(), FileSystem.LoadAsset("Image.webp"));
            if (webp == IntPtr.Zero) throw new Exception($"SDL IMAGE: {IMG_GetError()}");
        }

        public override void Events(SDL_Event e)
        {
            if (e.type == SDL_EventType.SDL_QUIT)
            {
                Platform.Current.IsRunning = false;
                return;
            }
            
            if (e.type == SDL_EventType.SDL_MOUSEBUTTONDOWN)
            {
                test++; if (test > 3) test = 0;
                testimage = IntPtr.Zero;

                if (test == 0)
                {
                    testimage = png;
                }
                else if (test == 1)
                {
                    testimage = jpg;
                }
                else if (test == 2)
                {
                    testimage = bmp;
                }
                else if (test == 3)
                {
                    testimage = webp;
                }
            }
        }
        
        public override void Render()
        {
            Graphics.ClearColor(255, 128, 128, 128);
            Graphics.Begin();
            
            SDL_RenderCopy(Window.GetRenderer(), testimage, IntPtr.Zero, IntPtr.Zero);
            
            Graphics.End();
        }
    }
}