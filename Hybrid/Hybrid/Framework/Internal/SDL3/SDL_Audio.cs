using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    // Default Devices
    internal const uint DefaultPlaybackDevice = 0xFFFFFFFFu;
    internal const uint DefaultRecordingDevice = 0xFFFFFFFEu;
    
        
    // Open Audio Device
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern uint SDL_OpenAudioDevice(uint device, SDL.AudioSpec* spec);
    internal static uint OpenAudioDevice(uint device, SDL.AudioSpec spec)
    {
        return SDL_OpenAudioDevice(device, &spec);
    }
    
    // Close Audio Device
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_CloseAudioDevice(uint device);
    internal static void CloseAudioDevice(uint device)
    {
        SDL_CloseAudioDevice(device);
    }
}