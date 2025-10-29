using System.Runtime.InteropServices.JavaScript;
using Hybrid;
using App;

public partial class Program
{
    [JSExport]
    public static void Main()
    {
        Platform.Web(new AppConfig());
    }
}