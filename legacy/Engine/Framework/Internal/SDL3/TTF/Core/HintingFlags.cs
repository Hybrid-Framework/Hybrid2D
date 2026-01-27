using System.Runtime.InteropServices;

internal static unsafe partial class SDL_ttf
{
    public enum HintingFlags : int
    {
        Invalid = -1,
        Normal = 0,
        Light = 1,
        Mono = 2,
        None = 3,
        LightSubpixel = 4
    }
}