using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Poll Events
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_PollEvent(out SDL.Event e);
    public static bool PollEvent(out SDL.Event e)
    {
        return SDL_PollEvent(out e);
    }
}