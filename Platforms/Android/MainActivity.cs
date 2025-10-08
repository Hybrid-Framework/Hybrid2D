using Android.Content.PM;
using Org.Libsdl.App;
using Hybrid.Platforms;
using Hybrid;
using App;

[Activity(
    Label = "Android", 
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
    protected override string[] GetLibraries() => ["SDL3", "SDL3_image", "SDL3_mixer", "SDL3_ttf"];
    
    protected override void Main()
    {
        Platform.Create(new PlatformAndroid(new Game()));
        Platform.Current.Run();
    }
}