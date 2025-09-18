using Engine.Platforms;
using Engine;
using App;

public static class Program
{
    public static void Main()
    {
        Platform.Create(new PlatformDesktop(new Game()));
    }
}