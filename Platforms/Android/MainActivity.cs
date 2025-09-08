using Android.Content.PM;
using Org.Libsdl.App;

[Activity(Label = "Android", 
    Exported = true,
    MainLauncher = true,
    HardwareAccelerated = true,
    AlwaysRetainTaskState = true,
    LaunchMode = LaunchMode.SingleInstance,
    Theme = "@android:style/Theme.NoTitleBar.Fullscreen",
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize
    )]
public class MainActivity : SDLActivity
{
    protected override string[] GetLibraries() => ["SDL2", "SDL2_mixer"];
    
    protected override void Entry()
    {
        using (var app = new Engine.Game("Hello", 800, 600, SDL2.SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN | SDL2.SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE))
        {
            while (app.Update())
            {
                
            }
        }
    }
}