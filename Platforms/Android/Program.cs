using Android.Content.PM;
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
    
}