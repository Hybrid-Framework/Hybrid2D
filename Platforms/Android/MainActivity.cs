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
    protected override string[] GetLibraries() => ["SDL2", "SDL2_image", "SDL2_mixer", "SDL2_ttf"];
    
    protected override void Main()
    {
        Platform.Create(new PlatformAndroid(new Game2()));
        Platform.Current.Run();
    }
}