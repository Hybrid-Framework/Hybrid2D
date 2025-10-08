using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Get Power Info
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.PowerState SDL_GetPowerInfo(out int seconds, out int percent);
    public static (SDL.PowerState state, int seconds, int percent) GetPowerInfo()
    {
        SDL.PowerState state = SDL_GetPowerInfo(out int seconds, out int percent);
        return (state, seconds, percent);
    }
}