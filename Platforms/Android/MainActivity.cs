using Android.Content.PM;
using Org.Libsdl.App;
using Engine.Platforms;
using Engine;
using App;

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
    protected override string[] GetLibraries() => ["SDL2", "SDL2_image", "SDL2_mixer", "SDL2_ttf"];
    
    protected override void Main()
    {
        Platform.Create(new PlatformAndroid(new Game()));
        Platform.Current.Run();
    }
}