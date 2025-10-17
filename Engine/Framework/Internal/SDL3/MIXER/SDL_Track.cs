using System.Runtime.InteropServices;

public static unsafe partial class SDL_mixer
{
    // Create Track
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Track* MIX_CreateTrack(SDL.Mixer* mixer);
    public static SDL.Track* CreateTrack(SDL.Mixer* mixer)
    {
        return MIX_CreateTrack(mixer);
    }
    
    // Destroy Track
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void MIX_DestroyTrack(SDL.Track* track);
    public static void DestroyTrack(SDL.Track* track)
    {
        MIX_DestroyTrack(track);
    }
    
    // Get Track Mixer
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Mixer* MIX_GetTrackMixer(SDL.Track* track);
    public static SDL.Mixer* GetTrackMixer(SDL.Track* track)
    {
        return MIX_GetTrackMixer(track);
    }
    
    // Set Track Audio
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_SetTrackAudio(SDL.Track* track, SDL.Audio* audio);
    public static bool SetTrackAudio(SDL.Track* track, SDL.Audio* audio)
    {
        return MIX_SetTrackAudio(track, audio);
    }
    
    // Set Track Playback Position
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_SetTrackPlaybackPosition(SDL.Track* track, long frames);
    public static bool SetTrackPlaybackPosition(SDL.Track* track, long frames)
    {
        return MIX_SetTrackPlaybackPosition(track, frames);
    }
    
    // Get Track Playback Position
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern long MIX_GetTrackPlaybackPosition(SDL.Track* track);
    public static long GetTrackPlaybackPosition(SDL.Track* track)
    {
        return MIX_GetTrackPlaybackPosition(track);
    }
    
    // Get Track Audio
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Audio* MIX_GetTrackAudio(SDL.Track* track);
    public static SDL.Audio* GetTrackAudio(SDL.Track* track)
    {
        return MIX_GetTrackAudio(track);
    }
    
    // Get Track Remaining
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern long MIX_GetTrackRemaining(SDL.Track* track);
    public static long GetTrackRemaining(SDL.Track* track)
    {
        return MIX_GetTrackRemaining(track);
    }
    
    // Track MS To Frames
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern long MIX_TrackMSToFrames(SDL.Track* track, long ms);
    public static long TrackMSToFrames(SDL.Track* track, long ms)
    {
        return MIX_TrackMSToFrames(track, ms);
    }
    
    // Track Frames To MS
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern long MIX_TrackFramesToMS(SDL.Track* track, long frames);
    public static long TrackFramesToMS(SDL.Track* track, long frames)
    {
        return MIX_TrackFramesToMS(track, frames);
    }
    
    // Play Track
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_PlayTrack(SDL.Track* track, uint properties);
    public static bool PlayTrack(SDL.Track* track, uint properties)
    {
        return MIX_PlayTrack(track, properties);
    }
    
    // Stop Track
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_StopTrack(SDL.Track* track, long fadeframes);
    public static bool StopTrack(SDL.Track* track, long fadeframes)
    {
        return MIX_StopTrack(track, fadeframes);
    }
    
    // Stop All Tracks
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_StopAllTracks(SDL.Mixer* mixer, long fadems);
    public static bool StopAllTracks(SDL.Mixer* mixer, long fadems)
    {
        return MIX_StopAllTracks(mixer, fadems);
    }
    
    // Pause Track
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_PauseTrack(SDL.Track* track);
    public static bool PauseTrack(SDL.Track* track)
    {
        return MIX_PauseTrack(track);
    }
    
    // Pause All Tracks
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_PauseAllTracks(SDL.Mixer* mixer);
    public static bool PauseAllTracks(SDL.Mixer* mixer)
    {
        return MIX_PauseAllTracks(mixer);
    }
    
    // Resume Track
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_ResumeTrack(SDL.Track* track);
    public static bool ResumeTrack(SDL.Track* track)
    {
        return MIX_ResumeTrack(track);
    }
    
    // Resume All Tracks
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_ResumeAllTracks(SDL.Mixer* mixer);
    public static bool ResumeAllTracks(SDL.Mixer* mixer)
    {
        return MIX_ResumeAllTracks(mixer);
    }
    
    // Track Playing
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_TrackPlaying(SDL.Track* track);
    public static bool TrackPlaying(SDL.Track* track)
    {
        return MIX_TrackPlaying(track);
    }
    
    // Track Paused
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_TrackPaused(SDL.Track* track);
    public static bool TrackPaused(SDL.Track* track)
    {
        return MIX_TrackPaused(track);
    }
    
    // Track Looping
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_TrackLooping(SDL.Track* track);
    public static bool TrackLooping(SDL.Track* track)
    {
        return MIX_TrackLooping(track);
    }
    
    // Set Track Gain
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_SetTrackGain(SDL.Track* track, float gain);
    public static bool SetTrackGain(SDL.Track* track, float gain)
    {
        return MIX_SetTrackGain(track, gain);
    }
    
    // Get Track Gain
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern float MIX_GetTrackGain(SDL.Track* track);
    public static float GetTrackGain(SDL.Track* track)
    {
        return MIX_GetTrackGain(track);
    }
    
    // Set Track Frequency Ratio
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_SetTrackFrequencyRatio(SDL.Track* track, float ratio);
    public static bool SetTrackFrequencyRatio(SDL.Track* track, float ratio)
    {
        return MIX_SetTrackFrequencyRatio(track, ratio);
    }
    
    // Get Track Frequency Ratio
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern float MIX_GetTrackFrequencyRatio(SDL.Track* track);
    public static float GetTrackFrequencyRatio(SDL.Track* track)
    {
        return MIX_GetTrackFrequencyRatio(track);
    }
    
    // Set Track Stereo
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_SetTrackStereo(SDL.Track* track, StereoGains* gains);
    public static bool SetTrackStereo(SDL.Track* track, StereoGains gains)
    {
        return MIX_SetTrackStereo(track, &gains);
    }
    
    // Set Track 3D Position
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_SetTrack3DPosition(SDL.Track* track, Point3D* position);
    public static bool SetTrack3DPosition(SDL.Track* track, Point3D position)
    {
        return MIX_SetTrack3DPosition(track, &position);
    }
    
    // Get Track 3D Position
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_GetTrack3DPosition(SDL.Track* track, out Point3D position);
    public static bool GetTrack3DPosition(SDL.Track* track, out Point3D position)
    {
        return MIX_GetTrack3DPosition(track, out position);
    }
}