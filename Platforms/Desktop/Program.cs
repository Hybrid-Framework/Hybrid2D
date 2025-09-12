using Engine.Platforms;
using Engine;

public static class Program
{
    public static void Main()
    {
        Platform.Create(new PlatformDesktop(new Game2()));
        Platform.Current.Run();
    }
}