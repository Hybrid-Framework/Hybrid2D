using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Open Audio Device
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.AudioDevice SDL_OpenAudioDevice(SDL.AudioDevice device, SDL.AudioSpec* spec);
    public static SDL.AudioDevice OpenAudioDevice(SDL.AudioDevice device, SDL.AudioSpec spec)
    {
        return SDL_OpenAudioDevice(device, &spec);
    }
    
    // Close Audio Device
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_CloseAudioDevice(SDL.AudioDevice device);
    public static void CloseAudioDevice(SDL.AudioDevice device)
    {
        SDL_CloseAudioDevice(device);
    }
}