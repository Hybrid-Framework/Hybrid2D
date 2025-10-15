using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    public enum LogCategory
    {
        Application = 0,
        Error = 1,
        Assert = 2,
        System = 3,
        Audio = 4,
        Video = 5,
        Render = 6,
        Input = 7,
        Custom = 19,
    }
}