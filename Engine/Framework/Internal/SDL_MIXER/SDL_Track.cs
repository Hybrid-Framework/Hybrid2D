using System.Runtime.InteropServices;

public static unsafe partial class SDL_mixer
{
    // Create Track
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr MIX_CreateTrack(IntPtr mixer);
    public static IntPtr CreateTrack(IntPtr mixer)
    {
        return MIX_CreateTrack(mixer);
    }
    
    // Destroy Track
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void MIX_DestroyTrack(IntPtr track);
    public static void DestroyTrack(IntPtr track)
    {
        MIX_DestroyTrack(track);
    }
    
    // Get Track Mixer
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr MIX_GetTrackMixer(IntPtr track);
    public static IntPtr GetTrackMixer(IntPtr track)
    {
        return MIX_GetTrackMixer(track);
    }
    
    // Set Track Audio
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_SetTrackAudio(IntPtr track, IntPtr audio);
    public static bool SetTrackAudio(IntPtr track, IntPtr audio)
    {
        return MIX_SetTrackAudio(track, audio);
    }
    
    // Get Track Audio
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr MIX_GetTrackAudio(IntPtr track);
    public static IntPtr GetTrackAudio(IntPtr track)
    {
        return MIX_GetTrackAudio(track);
    }
    
    // Set Track Playback Position
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_SetTrackPlaybackPosition(IntPtr track, long frames);
    public static bool SetTrackPlaybackPosition(IntPtr track, long frames)
    {
        return MIX_SetTrackPlaybackPosition(track, frames);
    }
    
    // Get Track Playback Position
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern long MIX_GetTrackPlaybackPosition(IntPtr track);
    public static long GetTrackPlaybackPosition(IntPtr track)
    {
        return MIX_GetTrackPlaybackPosition(track);
    }
    
    // Get Track Remaining
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern long MIX_GetTrackRemaining(IntPtr track);
    public static long GetTrackRemaining(IntPtr track)
    {
        return MIX_GetTrackRemaining(track);
    }
    
    // Track MS to Frames
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern long MIX_TrackMSToFrames(IntPtr track, long ms);
    public static long TrackMSToFrames(IntPtr track, long ms)
    {
        return MIX_TrackMSToFrames(track, ms);
    }
    
    // Track Frames To MS
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern long MIX_TrackFramesToMS(IntPtr track, long frames);
    public static long TrackFramesToMS(IntPtr track, long frames)
    {
        return MIX_TrackFramesToMS(track, frames);
    }
    
    // Play Track
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_PlayTrack(IntPtr track, uint properties);
    public static bool PlayTrack(IntPtr track, uint properties)
    {
        return MIX_PlayTrack(track, properties);
    }
    
    // Stop Track
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_StopTrack(IntPtr track, long fadeframes);
    public static bool StopTrack(IntPtr track, long fadeframes)
    {
        return MIX_StopTrack(track, fadeframes);
    }
    
    // Stop All Tracks
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_StopAllTracks(IntPtr mixer, long fadems);
    public static bool StopAllTracks(IntPtr mixer, long fadems)
    {
        return MIX_StopAllTracks(mixer, fadems);
    }
    
    // Pause Track
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_PauseTrack(IntPtr track);
    public static bool PauseTrack(IntPtr track)
    {
        return MIX_PauseTrack(track);
    }
    
    // Pause All Tracks
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_PauseAllTracks(IntPtr mixer);
    public static bool PauseAllTracks(IntPtr mixer)
    {
        return MIX_PauseAllTracks(mixer);
    }
    
    // Resume Track
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_ResumeTrack(IntPtr track);
    public static bool ResumeTrack(IntPtr track)
    {
        return MIX_ResumeTrack(track);
    }
    
    // Resume All Tracks
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_ResumeAllTracks(IntPtr mixer);
    public static bool ResumeAllTracks(IntPtr mixer)
    {
        return MIX_ResumeAllTracks(mixer);
    }
    
    // Track Playing
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_TrackPlaying(IntPtr track);
    public static bool TrackPlaying(IntPtr track)
    {
        return MIX_TrackPlaying(track);
    }
    
    // Track Paused
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_TrackPaused(IntPtr track);
    public static bool TrackPaused(IntPtr track)
    {
        return MIX_TrackPaused(track);
    }
    
    // Track Looping
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_TrackLooping(IntPtr track);
    public static bool TrackLooping(IntPtr track)
    {
        return MIX_TrackLooping(track);
    }
    
    // Set Track Gain
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_SetTrackGain(IntPtr track, float gain);
    public static bool SetTrackGain(IntPtr track, float gain)
    {
        return MIX_SetTrackGain(track, gain);
    }
    
    // Get Track Gain
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern float MIX_GetTrackGain(IntPtr track);
    public static float GetTrackGain(IntPtr track)
    {
        return MIX_GetTrackGain(track);
    }
    
    // Set Track Frequency Ratio
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_SetTrackFrequencyRatio(IntPtr track, float ratio);
    public static bool SetTrackFrequencyRatio(IntPtr track, float ratio)
    {
        return MIX_SetTrackFrequencyRatio(track, ratio);
    }
    
    // Get Track Frequency Ratio
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern float MIX_GetTrackFrequencyRatio(IntPtr track);
    public static float GetTrackFrequencyRatio(IntPtr track)
    {
        return MIX_GetTrackFrequencyRatio(track);
    }
    
    // Set Track Stereo
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_SetTrackStereo(IntPtr track, StereoGains* gains);
    public static bool SetTrackStereo(IntPtr track, StereoGains gains)
    {
        return MIX_SetTrackStereo(track, &gains);
    }
    
    // Set Track 3D Position
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_SetTrack3DPosition(IntPtr track, StereoPosition* position);
    public static bool SetTrack3DPosition(IntPtr track, StereoPosition position)
    {
        return MIX_SetTrack3DPosition(track, &position);
    }
    
    // Get Track 3D Position
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_GetTrack3DPosition(IntPtr track, out StereoPosition position);
    public static bool GetTrack3DPosition(IntPtr track, out StereoPosition position)
    {
        return MIX_GetTrack3DPosition(track, out position);
    }
}