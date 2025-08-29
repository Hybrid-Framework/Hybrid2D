using Android.Content.PM;
using Org.Libsdl.App;
using SDL = SDL2.SDL;

[Activity(Label = "Android", 
    Exported = true,
    MainLauncher = true,
    HardwareAccelerated = true,
    AlwaysRetainTaskState = true,
    LaunchMode = LaunchMode.SingleInstance,
    Theme = "@android:style/Theme.NoTitleBar.Fullscreen"
    )]
public class MainActivity : SDLActivity
{
    protected override void Entry()
    {
        using (var app = new Engine.Game("Hello", 800, 600, SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN))
        {
            while (app.Update())
            {
                
            }
        }
    }
}