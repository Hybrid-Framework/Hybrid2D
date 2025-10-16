using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Default Devices
    public const uint DefaultPlaybackDevice = 0xFFFFFFFFu;
    public const uint DefaultRecordingDevice = 0xFFFFFFFEu;
    
        
    // Open Audio Device
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern uint SDL_OpenAudioDevice(uint device, SDL.AudioSpec* spec);
    public static uint OpenAudioDevice(uint device, SDL.AudioSpec spec)
    {
        return SDL_OpenAudioDevice(device, &spec);
    }
    
    // Close Audio Device
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_CloseAudioDevice(uint device);
    public static void CloseAudioDevice(uint device)
    {
        SDL_CloseAudioDevice(device);
    }
}