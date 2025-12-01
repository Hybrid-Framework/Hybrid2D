using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    // Poll Event
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_PollEvent(out SDL.Event e);
    public static bool PollEvent(out SDL.Event e)
    {
        return SDL_PollEvent(out e);
    }
    
    // Push Event
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_PushEvent(ref SDL.Event e);
    public static bool PushEvent(ref SDL.Event e)
    {
        return SDL_PushEvent(ref e);
    }
}