using Hybrid.Platforms;
using Hybrid;
using App;

public static class Program
{
    public static void Main(string[] args)
    {
        SDL.MainFunction entry = Entry;
        SDL.RunApp(0, IntPtr.Zero, entry, IntPtr.Zero);
    }

    private static int Entry(int argc, IntPtr argv)
    {
        Platform.Create(new PlatformIOS(new Game()));
        Platform.Current.Run();
        return 0;
    }
}