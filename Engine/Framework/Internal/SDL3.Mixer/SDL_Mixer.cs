using System.Runtime.InteropServices;

internal static unsafe partial class SDL_mixer
{
    // Create Mixer Device
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Mixer* MIX_CreateMixerDevice(uint deviceID, SDL.AudioSpec* spec);
    public static SDL.Mixer* CreateMixerDevice(uint deviceID, SDL.AudioSpec spec)
    {
        return MIX_CreateMixerDevice(deviceID, &spec);
    }
    
    // Create Mixer
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Mixer* MIX_CreateMixer(SDL.AudioSpec* spec);
    public static SDL.Mixer* CreateMixer(SDL.AudioSpec spec)
    {
        return MIX_CreateMixer(&spec);
    }
    
    // Destroy Mixer
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void MIX_DestroyMixer(SDL.Mixer* mixer);
    public static void DestroyMixer(SDL.Mixer* mixer)
    {
        MIX_DestroyMixer(mixer);
    }
    
    // Get Mixer Format
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_GetMixerFormat(SDL.Mixer* mixer, out SDL.AudioSpec spec);
    public static bool GetMixerFormat(SDL.Mixer* mixer, out SDL.AudioSpec spec)
    {
        return MIX_GetMixerFormat(mixer, out spec);
    }
    
    // Get Mixer Properties
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern uint MIX_GetMixerProperties(SDL.Mixer* mixer);
    public static uint GetMixerProperties(SDL.Mixer* mixer)
    {
        return MIX_GetMixerProperties(mixer);
    }
    
    // MS To Frames
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern long MIX_MSToFrames(int samplerate, long ms);
    public static long MSToFrames(int samplerate, long ms)
    {
        return MIX_MSToFrames(samplerate, ms);
    }
    
    // Frames To MS
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern long MIX_FramesToMS(int samplerate, long frames);
    public static long FramesToMS(int samplerate, long frames)
    {
        return MIX_FramesToMS(samplerate, frames);
    }
    
    // Set Master Gain
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_SetMasterGain(SDL.Mixer* mixer, float gain);
    public static bool SetMasterGain(SDL.Mixer* mixer, float gain)
    {
        return MIX_SetMasterGain(mixer, gain);
    }
    
    // Get Master Gain
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern float MIX_GetMasterGain(SDL.Mixer* mixer);
    public static float GetMasterGain(SDL.Mixer* mixer)
    {
        return MIX_GetMasterGain(mixer);
    }
    
    // Create Sine Wave Audio
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Audio* MIX_CreateSineWaveAudio(SDL.Mixer* mixer, int hz, float gain);
    public static SDL.Audio* CreateSineWaveAudio(SDL.Mixer* mixer, int hz, float gain)
    {
        return MIX_CreateSineWaveAudio(mixer, hz, gain);
    }
}