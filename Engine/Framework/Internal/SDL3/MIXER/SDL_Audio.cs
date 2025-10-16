using System.Runtime.InteropServices;

public static unsafe partial class SDL_mixer
{
    // Load Audio
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr MIX_LoadAudio(IntPtr mixer, byte* path, bool predecode);
    public static IntPtr LoadAudio(IntPtr mixer, string path, bool predecode)
    {
        var bytes = SDL.StringToUtf8(path);

        fixed (byte* utf8 = bytes)
        {
            return MIX_LoadAudio(mixer, utf8, predecode);
        }
    }
    
    // Destroy Audio
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void MIX_DestroyAudio(IntPtr audio);
    public static void DestroyAudio(IntPtr audio)
    {
        MIX_DestroyAudio(audio);
    }
    
    // Get Audio Properties
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern uint MIX_GetAudioProperties(IntPtr audio);
    public static uint GetAudioProperties(IntPtr audio)
    {
        return MIX_GetAudioProperties(audio);
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
    
    // Play Audio
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_PlayAudio(IntPtr mixer, IntPtr audio);
    public static bool PlayAudio(IntPtr mixer, IntPtr audio)
    {
        return MIX_PlayAudio(mixer, audio);
    }
    
    // Get Audio Title
    public static string GetAudioTitle(IntPtr audio)
    {
        uint properties = GetAudioProperties(audio);
        return SDL.GetStringProperty(properties, Properties.Audio_Title, String.Empty);
    }
    
    // Get Audio Artist
    public static string GetAudioArtist(IntPtr audio)
    {
        uint properties = GetAudioProperties(audio);
        return SDL.GetStringProperty(properties, Properties.Audio_Artist, String.Empty);
    }
    
    // Get Audio Album
    public static string GetAudioAlbum(IntPtr audio)
    {
        uint properties = GetAudioProperties(audio);
        return SDL.GetStringProperty(properties, Properties.Audio_Album, String.Empty);
    }
    
    // Get Audio Copyright
    public static string GetAudioCopyright(IntPtr audio)
    {
        uint properties = GetAudioProperties(audio);
        return SDL.GetStringProperty(properties, Properties.Audio_Copyright, String.Empty);
    }
    
    // Get Audio Track Number
    public static long GetAudioTrackNumber(IntPtr audio)
    {
        uint properties = GetAudioProperties(audio);
        return (int)SDL.GetNumberProperty(properties, Properties.Audio_Track, -1);
    }
    
    // Get Audio Total Tracks Count
    public static long GetAudioTotalTracksCount(IntPtr audio)
    {
        uint properties = GetAudioProperties(audio);
        return (int)SDL.GetNumberProperty(properties, Properties.Audio_TotalTracks, -1);
    }
    
    // Get Audio Year
    public static long GetAudioYear(IntPtr audio)
    {
        uint properties = GetAudioProperties(audio);
        return SDL.GetNumberProperty(properties, Properties.Audio_Year, -1);
    }
    
    // Get Audio Duration Frames
    public static long GetAudioDurationFrames(IntPtr audio)
    {
        uint properties = GetAudioProperties(audio);
        return SDL.GetNumberProperty(properties, Properties.Audio_DurationFrames, -1);
    }
    
    // Get Audio Duration Infinite
    public static bool GetAudioDurationInfinite(IntPtr audio)
    {
        uint properties = GetAudioProperties(audio);
        return SDL.GetBooleanProperty(properties, Properties.Audio_DurationInfinite, false);
    }
}