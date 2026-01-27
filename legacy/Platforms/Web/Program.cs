using System.Runtime.InteropServices.JavaScript;
using Hybrid;

public partial class Program
{
    [JSExport]
    public static void Main()
    {
        Bootstrap.Web(new App.Config());
    }
}