using System.Runtime.InteropServices.JavaScript;
using Hybrid.Platforms;
using Hybrid;
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
            Initialized = true;
            Console.WriteLine("Initialize");
            Platform.Create(new PlatformWeb(new Game()));
        }
        
        Platform.Current.Run();
    }
}