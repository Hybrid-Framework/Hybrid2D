using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Open Audio Device
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern uint SDL_OpenAudioDevice(uint device, SDL.AudioSpec* spec);
    public static uint OpenAudioDevice(AudioDevice device, SDL.AudioSpec spec)
    {
        return SDL_OpenAudioDevice((uint)device, &spec);
    }
    
    // Close Audio Device
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_CloseAudioDevice(uint device);
    public static void CloseAudioDevice(AudioDevice device)
    {
        SDL_CloseAudioDevice((uint)device);
    }
}