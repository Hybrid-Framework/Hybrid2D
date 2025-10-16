using System.Runtime.InteropServices;

public static unsafe partial class SDL_mixer
{
    // Create Mixer Device
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr MIX_CreateMixerDevice(uint deviceID, SDL.AudioSpec* spec);
    public static IntPtr CreateMixerDevice(uint deviceID, SDL.AudioSpec spec)
    {
        return MIX_CreateMixerDevice(deviceID, &spec);
    }
    
    // Create Mixer
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr MIX_CreateMixer(SDL.AudioSpec* spec);
    public static IntPtr CreateMixer(SDL.AudioSpec spec)
    {
        return MIX_CreateMixer(&spec);
    }
    
    // Destroy Mixer
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void MIX_DestroyMixer(IntPtr mixer);
    public static void DestroyMixer(IntPtr mixer)
    {
        MIX_DestroyMixer(mixer);
    }
    
    // Get Mixer Format
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_GetMixerFormat(IntPtr mixer, out SDL.AudioSpec spec);
    public static bool GetMixerFormat(IntPtr mixer, out SDL.AudioSpec spec)
    {
        return MIX_GetMixerFormat(mixer, out spec);
    }
    
    // Get Mixer Properties
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern uint MIX_GetMixerProperties(IntPtr mixer);
    public static uint GetMixerProperties(IntPtr mixer)
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
    private static extern SDL.Bool MIX_SetMasterGain(IntPtr mixer, float gain);
    public static bool SetMasterGain(IntPtr mixer, float gain)
    {
        return MIX_SetMasterGain(mixer, gain);
    }
    
    // Get Master Gain
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern float MIX_GetMasterGain(IntPtr mixer);
    public static float GetMasterGain(IntPtr mixer)
    {
        return MIX_GetMasterGain(mixer);
    }
}