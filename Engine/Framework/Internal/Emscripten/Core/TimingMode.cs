using System.Runtime.InteropServices;

internal static unsafe partial class Emscripten
{
    public enum TimingMode : int
    {
        Timeout = 0,
        RequestFrameAnimation = 1,
        Immediate = 2
    }
}