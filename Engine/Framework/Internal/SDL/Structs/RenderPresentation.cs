using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    public enum RendererPresentation
    {
        Disabled = 0,
        Stretch = 1,
        Letterbox = 2,
        Overscan = 3,
        IntegerScale = 4,
    }
}