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
    protected override void Entry()
    {
        Platform.Create(new PlatformAndroid(new Game()));
        Platform.Current.Run();
    }
}