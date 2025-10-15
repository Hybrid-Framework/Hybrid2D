using System.Runtime.InteropServices;

public static unsafe partial class SDL_mixer
{
    public static class Properties
    {
        // Audio
        public const string PropertyAudioYear = "SDL_mixer.metadata.year";
        public const string PropertyAudioAlbum = "SDL_mixer.metadata.album";
        public const string PropertyAudioTitle = "SDL_mixer.metadata.title";
        public const string PropertyAudioArtist = "SDL_mixer.metadata.artist";
        public const string PropertyAudioTrackNumber = "SDL_mixer.metadata.track";
        public const string PropertyAudioCopyright = "SDL_mixer.metadata.copyright";
        public const string PropertyAudioTotalTracks = "SDL_mixer.metadata.total_tracks";
    }
}