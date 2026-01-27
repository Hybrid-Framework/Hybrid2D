using System.Runtime.InteropServices;

internal static unsafe partial class SDL_mixer
{
    public static class Properties
    {
        // Mixer
        public const string Mixer_Loops = "SDL_mixer.play.loops"; // number
        public const string Mixer_MaxFrames = "SDL_mixer.play.max_frame"; // number
        public const string Mixer_MaxMilliseconds = "SDL_mixer.play.max_milliseconds"; // number
        public const string Mixer_StartFrame = "SDL_mixer.play.start_frame"; // number
        public const string Mixer_StartMillisecond = "SDL_mixer.play.start_millisecond"; // number
        public const string Mixer_LoopStartFrameNumber = "SDL_mixer.play.loop_start_frame"; // number
        public const string Mixer_LoopStartMillisecond = "SDL_mixer.play.loop_start_millisecond"; // number
        public const string Mixer_FadeInFrames = "SDL_mixer.play.fade_in_frames"; // number
        public const string Mixer_FadeInMilliseconds = "SDL_mixer.play.fade_in_milliseconds"; // number
        public const string Mixer_AppendSilenceFrames = "SDL_mixer.play.append_silence_frames"; // number
        public const string Mixer_AppendSilenceMilliseconds = "SDL_mixer.play.append_silence_milliseconds"; // number
        
        // Audio
        public const string Audio_Title = "SDL_mixer.metadata.title"; // string
        public const string Audio_Artist = "SDL_mixer.metadata.artist"; // string
        public const string Audio_Album = "SDL_mixer.metadata.album"; // string
        public const string Audio_Copyright = "SDL_mixer.metadata.copyright"; // string
        public const string Audio_Track = "SDL_mixer.metadata.track"; // number
        public const string Audio_TotalTracks = "SDL_mixer.metadata.total_tracks"; // number
        public const string Audio_Year = "SDL_mixer.metadata.year"; // number
        public const string Audio_DurationFrames = "SDL_mixer.metadata.duration_frames"; // number
        public const string Audio_DurationInfinite = "SDL_mixer.metadata.duration_infinite"; // boolean
    }
}