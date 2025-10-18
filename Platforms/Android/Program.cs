using Android.Content.PM;
using Hybrid.Platforms;
using Org.Libsdl.App;
using Hybrid;
using App;

[Activity(
    Label = "Hybrid",
    Exported = true,
    MainLauncher = true,
    HardwareAccelerated = true,
    AlwaysRetainTaskState = true,
    LaunchMode = LaunchMode.SingleInstance,
    Theme = "@android:style/Theme.NoTitleBar.Fullscreen",
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize
)]
public class Program : SDLActivity
{
    protected override string[] GetLibraries() => ["SDL3", "SDL3_image", "SDL3_mixer", "SDL3_ttf"];
    
    protected override void Main()
    {
        Platform.Create(new PlatformAndroid(new Game()));
        Platform.Current.Run();
    }
}