using System.Runtime.InteropServices;

public static unsafe partial class SDL_mixer
{
    // Load Audio
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr MIX_LoadAudio(IntPtr mixer, byte* path, SDL.Bool decode);
    public static IntPtr LoadAudio(IntPtr mixer, string path, bool decode)
    {
        var bytes = SDL.StringToUtf8(path);

        fixed (byte* utf8 = bytes)
        {
            return MIX_LoadAudio(mixer, utf8, decode);
        }
    }
    
    // Destroy Audio
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void MIX_DestroyAudio(IntPtr audio);
    public static void DestroyAudio(IntPtr audio)
    {
        MIX_DestroyAudio(audio);
    }
    
    // Play Audio
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_PlayAudio(IntPtr mixer, IntPtr audio);
    public static bool PlayAudio(IntPtr mixer, IntPtr audio)
    {
        return MIX_PlayAudio(mixer, audio);
    }
    
    // Get Audio Duration
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern long MIX_GetAudioDuration(IntPtr audio);
    public static long GetAudioDuration(IntPtr audio)
    {
        return MIX_GetAudioDuration(audio);
    }
    
    // Get Audio Format
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_GetAudioFormat(IntPtr audio, out SDL.AudioSpec spec);
    public static bool GetAudioFormat(IntPtr audio, out SDL.AudioSpec spec)
    {
        return MIX_GetAudioFormat(audio, out spec);
    }
    
    // Get Audio Properties
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern uint MIX_GetAudioProperties(IntPtr audio);
    private static uint GetAudioProperties(IntPtr audio)
    {
        return MIX_GetAudioProperties(audio);
    }
    
    // Audio MS To Frames
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern long MIX_AudioMSToFrames(IntPtr audio, long ms);
    public static long AudioMSToFrames(IntPtr audio, long ms)
    {
        return MIX_AudioMSToFrames(audio, ms);
    }
    
    // Audio Frames To MS
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern long MIX_AudioFramesToMS(IntPtr audio, long frames);
    public static long AudioFramesToMS(IntPtr audio, long frames)
    {
        return MIX_AudioFramesToMS(audio, frames);
    }
    
    // Get Audio Title
    public static string GetAudioTitle(IntPtr audio)
    {
        uint properties = GetAudioProperties(audio);
        return SDL.GetStringProperty(properties, SDL_mixer.Properties.PropertyAudioTitle, String.Empty);
    }
    
    // Get Audio Album
    public static string GetAudioAlbum(IntPtr audio)
    {
        uint properties = GetAudioProperties(audio);
        return SDL.GetStringProperty(properties, SDL_mixer.Properties.PropertyAudioAlbum, String.Empty);
    }
    
    // Get Audio Artist
    public static string GetAudioArtist(IntPtr audio)
    {
        uint properties = GetAudioProperties(audio);
        return SDL.GetStringProperty(properties, SDL_mixer.Properties.PropertyAudioArtist, String.Empty);
    }
    
    // Get Audio Copyright
    public static string GetAudioCopyright(IntPtr audio)
    {
        uint properties = GetAudioProperties(audio);
        return SDL.GetStringProperty(properties, SDL_mixer.Properties.PropertyAudioCopyright, String.Empty);
    }
    
    // Get Audio Year
    public static long GetAudioYear(IntPtr audio)
    {
        uint properties = GetAudioProperties(audio);
        return SDL.GetNumberProperty(properties, SDL_mixer.Properties.PropertyAudioYear, -1);
    }
    
    // Get Audio Track Number
    public static long GetAudioTrackNumber(IntPtr audio)
    {
        uint properties = GetAudioProperties(audio);
        return SDL.GetNumberProperty(properties, SDL_mixer.Properties.PropertyAudioTrackNumber, -1);
    }
    
    // Get Audio Total Tracks Count
    public static long GetAudioTotalTracks(IntPtr audio)
    {
        uint properties = GetAudioProperties(audio);
        return SDL.GetNumberProperty(properties, SDL_mixer.Properties.PropertyAudioTotalTracks, -1);
    }
}