using System.Runtime.InteropServices.JavaScript;
using Engine.Platforms;
using Engine;
using App;

public static partial class Program
{
    [JSImport("setMainLoop", "main.js")]
    private static partial void SetMainLoop([JSMarshalAs<JSType.Function>] Action cb);
    private static bool Initialized;

    [JSExport]
    private static void Main()
    {
        if (!Initialized)
        {
            Platform.Create(new PlatformWeb(new Game()));
            Initialized = true;
        }
        
        Platform.Current.Run();
    }
}