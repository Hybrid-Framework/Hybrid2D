using Android.Content.PM;
using App;
using Org.Libsdl.App;

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
    protected override string[] GetLibraries()
    {
        return new[] { "SDL3", "SDL3_image", "SDL3_mixer", "SDL3_ttf" };
    }
    
    protected override void Main()
    {
        var game = new Game();
        {
            game.Run();
        }
    }
}
