using static Engine.Internal.SDL2.SDL;
using Android.Content.PM;
using Engine.Platforms;
using Org.Libsdl.App;
using Engine;

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
    private static bool Initialized = false;
    
    protected override string[] GetLibraries() => ["SDL2", "SDL2_mixer"];
    
    protected override void Entry()
    {
        if (!Initialized)
        {
            Platform.Create(new PlatformAndroid(new Game()));
            Initialized = true;
        }
        
        Platform.Current.Run();
    }
}