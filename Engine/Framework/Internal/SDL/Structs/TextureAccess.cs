using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    public enum TextureAccess
    {
        Static = 0,
        Streaming = 1,
        Target = 2,
    }
}