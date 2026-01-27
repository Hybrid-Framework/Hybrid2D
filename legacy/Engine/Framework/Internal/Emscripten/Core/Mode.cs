using System.Runtime.InteropServices;

internal static unsafe partial class Emscripten
{
    public enum Mode : int
    {
        Timeout = 0,
        RequestFrameAnimation = 1,
        Immediate = 2
    }
}