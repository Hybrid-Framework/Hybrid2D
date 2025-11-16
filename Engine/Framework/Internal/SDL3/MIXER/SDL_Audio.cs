using System.Runtime.InteropServices;

internal static unsafe partial class SDL_mixer
{
    // Load Audio
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Audio* MIX_LoadAudio(SDL.Mixer* mixer, byte* path, bool predecode);
    public static SDL.Audio* LoadAudio(SDL.Mixer* mixer, string path, bool predecode)
    {
        var bytes = SDL.StringToUtf8(path);

        fixed (byte* utf8 = bytes)
        {
            return MIX_LoadAudio(mixer, utf8, predecode);
        }
    }
    
    // Destroy Audio
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void MIX_DestroyAudio(SDL.Audio* audio);
    public static void DestroyAudio(SDL.Audio* audio)
    {
        MIX_DestroyAudio(audio);
    }
    
    // Get Audio Properties
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern uint MIX_GetAudioProperties(SDL.Audio* audio);
    public static uint GetAudioProperties(SDL.Audio* audio)
    {
        return MIX_GetAudioProperties(audio);
    }
    
    // Get Audio Duration
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern long MIX_GetAudioDuration(SDL.Audio* audio);
    public static long GetAudioDuration(SDL.Audio* audio)
    {
        return MIX_GetAudioDuration(audio);
    }
    
    // Get Audio Format
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_GetAudioFormat(SDL.Audio* audio, out SDL.AudioSpec spec);
    public static bool GetAudioFormat(SDL.Audio* audio, out SDL.AudioSpec spec)
    {
        return MIX_GetAudioFormat(audio, out spec);
    }
    
    // Audio MS To Frames
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern long MIX_AudioMSToFrames(SDL.Audio* audio, long ms);
    public static long AudioMSToFrames(SDL.Audio* audio, long ms)
    {
        return MIX_AudioMSToFrames(audio, ms);
    }
    
    // Audio Frames To MS
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern long MIX_AudioFramesToMS(SDL.Audio* audio, long frames);
    public static long AudioFramesToMS(SDL.Audio* audio, long frames)
    {
        return MIX_AudioFramesToMS(audio, frames);
    }
    
    // Play Audio
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_PlayAudio(SDL.Mixer* mixer, SDL.Audio* audio);
    public static bool PlayAudio(SDL.Mixer* mixer, SDL.Audio* audio)
    {
        return MIX_PlayAudio(mixer, audio);
    }
    
    // Get Audio Title
    public static string GetAudioTitle(SDL.Audio* audio)
    {
        uint properties = GetAudioProperties(audio);
        return SDL.GetStringProperty(properties, Properties.Audio_Title, String.Empty);
    }
    
    // Get Audio Artist
    public static string GetAudioArtist(SDL.Audio* audio)
    {
        uint properties = GetAudioProperties(audio);
        return SDL.GetStringProperty(properties, Properties.Audio_Artist, String.Empty);
    }
    
    // Get Audio Album
    public static string GetAudioAlbum(SDL.Audio* audio)
    {
        uint properties = GetAudioProperties(audio);
        return SDL.GetStringProperty(properties, Properties.Audio_Album, String.Empty);
    }
    
    // Get Audio Copyright
    public static string GetAudioCopyright(SDL.Audio* audio)
    {
        uint properties = GetAudioProperties(audio);
        return SDL.GetStringProperty(properties, Properties.Audio_Copyright, String.Empty);
    }
    
    // Get Audio Track Number
    public static long GetAudioTrackNumber(SDL.Audio* audio)
    {
        uint properties = GetAudioProperties(audio);
        return (int)SDL.GetNumberProperty(properties, Properties.Audio_Track, -1);
    }
    
    // Get Audio Total Tracks Count
    public static long GetAudioTotalTracksCount(SDL.Audio* audio)
    {
        uint properties = GetAudioProperties(audio);
        return (int)SDL.GetNumberProperty(properties, Properties.Audio_TotalTracks, -1);
    }
    
    // Get Audio Year
    public static long GetAudioYear(SDL.Audio* audio)
    {
        uint properties = GetAudioProperties(audio);
        return SDL.GetNumberProperty(properties, Properties.Audio_Year, -1);
    }
    
    // Get Audio Duration Frames
    public static long GetAudioDurationFrames(SDL.Audio* audio)
    {
        uint properties = GetAudioProperties(audio);
        return SDL.GetNumberProperty(properties, Properties.Audio_DurationFrames, -1);
    }
    
    // Get Audio Duration Infinite
    public static bool GetAudioDurationInfinite(SDL.Audio* audio)
    {
        uint properties = GetAudioProperties(audio);
        return SDL.GetBooleanProperty(properties, Properties.Audio_DurationInfinite, false);
    }
}