using Hybrid;
using App;
using Game = App.Game;

public class Program
{
    public static void Main()
    {
        Platform.Create(new PlatformIOS(new Game()));
    }
}