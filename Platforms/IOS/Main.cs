using System.Runtime.InteropServices;
using Hybrid.Platforms;
using Hybrid;
using App;

public static class Program
{
    public static void Main(string[] args)
    {
        
    }

    private static int Entry(int argc, IntPtr argv)
    {
        Platform.Create(new PlatformIOS(new Game()));
        Platform.Current.Run();
        return 0;
    }
}