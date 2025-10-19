using System.Runtime.InteropServices.JavaScript;
using System;

public partial class Program
{
    [JSImport("setMainLoop", "main.js")]
    public static partial void SetMainLoop([JSMarshalAs<JSType.Function>] Action cb);

    [JSExport]
    public static void Main()
    {
        
    }
}