using System.Runtime.InteropServices.JavaScript;
using System;

public abstract partial class Activity
{
    [JSExport]
    public static void Main()
    {
        var activity = new Program();
        {
            activity.Entry();
        }
    }

    public abstract void Entry();
}