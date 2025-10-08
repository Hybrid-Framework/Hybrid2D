using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    public enum BlendFactor
    {
        Zero = 1,
        One = 2,
        SourceColor = 3,
        OneMinusSourceColor = 4,
        SourceAlpha = 5,
        OneMinusSourceAlpha = 6,
        DestinationColor = 7,
        OneMinusDestinationColor = 8,
        DestinationAlpha = 9,
        OneMinusDestinationAlpha = 10,
    }
}