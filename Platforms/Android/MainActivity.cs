using Org.Libsdl.App;

namespace Android
{
    [Activity(Label = "Android", MainLauncher = true)]
    public class MainActivity : SDLActivity
    {
        protected override string[] GetLibraries() => ["SDL2", "SDL2_image", "SDL2_ttf", "SDL2_mixer"];

        protected override void Entry()
        {
            using (var app = new Engine.Tests("Hello", 800, 600, SDL2.SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN))
            {
                while (app.Update())
                {
                
                }
            }
        }
    }
}