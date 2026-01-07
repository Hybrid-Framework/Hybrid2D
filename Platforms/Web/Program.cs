using System.Runtime.InteropServices.JavaScript;
using App;

public partial class Program
{
    [JSExport]
    public static void Main()
    {
        var game = new Game();
        {
            game.Run();
        }
    }
}