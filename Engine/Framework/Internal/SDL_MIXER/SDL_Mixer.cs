using System.Runtime.InteropServices;

public static unsafe partial class SDL_mixer
{
    // Init
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_Init();
    public static bool Init()
    {
        return MIX_Init();
    }
    
    // Quit
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void MIX_Quit();
    public static void Quit()
    {
        MIX_Quit();
    }
    
    // Create Mixer Device
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr MIX_CreateMixerDevice(uint device, SDL.AudioSpec* spec);
    public static IntPtr CreateMixerDevice(uint device, SDL.AudioSpec spec)
    {
        return MIX_CreateMixerDevice(device, &spec);
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