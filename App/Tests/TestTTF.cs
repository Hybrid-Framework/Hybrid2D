using static Hybrid.SDL2.SDL_ttf;
using static Hybrid.SDL2.SDL;
using Hybrid;

namespace App
{
    public class TestTTF : Behaviour
    {
        private string teststring = "World!";
        public IntPtr fontTexture;
        public IntPtr font;
        
        public override void Init()
        {
            Window.CreateWindow("Hybrid", 800, 600);
            
            font = TTF_OpenFont(FileSystem.LoadAsset("Font.ttf"), 256);
            if (font == IntPtr.Zero) throw new Exception($"SDL TTF: {TTF_GetError()}");
        }

        public override void Events(SDL_Event e)
        {
            if (e.type == SDL_EventType.SDL_QUIT)
            {
                Platform.Current.IsRunning = false;
                return;
            }
        }
        
        public override void Render()
        {
            Graphics.ClearColor(255, 128, 128, 128);
            Graphics.Begin();
            
            IntPtr fontSurface = TTF_RenderText_Solid(font, teststring, new SDL_Color { r = 255, g = 255, b = 255, a = 255 });
            
            if (fontSurface != IntPtr.Zero)
            {
                fontTexture = SDL_CreateTextureFromSurface(Window.GetRenderer(), fontSurface);
                SDL_FreeSurface(fontSurface);
                
                SDL_QueryTexture(fontTexture, out _, out _, out int texW, out int texH);
                SDL_Rect dstRect = new SDL_Rect { x = 10, y = 10, w = texW, h = texH };
                SDL_RenderCopy(Window.GetRenderer(), fontTexture, IntPtr.Zero, ref dstRect);
            }
            
            Graphics.End();
            
            SDL_DestroyTexture(fontTexture);
        }
    }
}