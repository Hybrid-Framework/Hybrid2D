using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    public enum FlipMode
    {
        None = 0,
        Horizontal = 1,
        Vertical = 2,
        HorizontalVertical = (Horizontal | Vertical)
    }
}