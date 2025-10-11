using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    public enum Orientation
    {
        Unknown = 0,
        Portrait = 3,
        Landscape = 1,
        PortraitFlipped = 4,
        LandscapeFlipped = 2,
    }
}