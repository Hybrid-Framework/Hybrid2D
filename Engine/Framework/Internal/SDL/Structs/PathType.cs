using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    public enum PathType
    {
        None = 0,
        File = 1,
        Directory = 2,
        Other = 3,
    }
}