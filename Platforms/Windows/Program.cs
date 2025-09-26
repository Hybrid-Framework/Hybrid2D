using Hybrid.Platforms;
using Hybrid;
using App;

public static class Program
{
    public static void Main()
    {
        Platform.Create(new PlatformDesktop(new TestIMAGE()));
        Platform.Current.Run();
    }
}