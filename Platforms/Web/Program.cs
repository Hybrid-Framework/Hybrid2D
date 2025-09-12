using System.Runtime.InteropServices.JavaScript;
using static Engine.Internal.SDL2.SDL;
using Engine;
using Engine.Platforms;

public static partial class Program
{
    [JSImport("setMainLoop", "main.js")]
    private static partial void SetMainLoop([JSMarshalAs<JSType.Function>] Action cb);
    private static bool Initialized;
    private static void Main() { }

    [JSExport]
    private static void Entry()
    {
        if (!Initialized)
        {
            Platform.Create(new PlatformWeb(new Game2()));
            Initialized = true;
        }
        
        Platform.Current.Run();
    }
}