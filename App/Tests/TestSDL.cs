using static Hybrid.SDL2.SDL;
using Hybrid;

namespace App
{
    public class TestSDL : Behaviour
    {
        public override void Init()
        {
            Window.CreateWindow("Hybrid", 800, 600);
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
            Graphics.End();
        }
    }
}