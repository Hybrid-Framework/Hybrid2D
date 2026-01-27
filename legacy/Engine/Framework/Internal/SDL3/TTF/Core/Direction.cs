using System.Runtime.InteropServices;

internal static unsafe partial class SDL_ttf
{
    public enum Direction : int
    {
        Invalid = 0,
        LeftToRight = 4,
        RightToLeft = 5,
        TopToBottom = 6,
        BottomToTop = 7
    }
}
