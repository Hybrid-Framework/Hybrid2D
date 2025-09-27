using static Hybrid.SDL2.SDL;
using static Hybrid.SDL2.SDL_image;
using static Hybrid.SDL2.SDL_mixer;
using static Hybrid.SDL2.SDL_ttf;

namespace Hybrid.SDL2
{
    public static class SDL_init
    {
        public static void Init()
        {
            SDL_SetHint(SDL_HINT_VIDEO_HIGHDPI_DISABLED, "0");
            SDL_SetHint(SDL_HINT_RENDER_SCALE_QUALITY, "nearest");
            SDL_SetHint(SDL_HINT_WINDOWS_DPI_AWARENESS, "permonitor");
            SDL_SetHint(SDL_HINT_WINDOWS_DPI_SCALING, "1");
            
            if (SDL_Init(SDL_INIT_VIDEO | SDL_INIT_AUDIO) < 0) throw new Exception($"SDL: {SDL_GetError()}");
            
            if (IMG_Init(IMG_InitFlags.IMG_INIT_JPG | IMG_InitFlags.IMG_INIT_PNG) < 0) throw new Exception($"SDL IMAGE: {IMG_GetError()}");

            if (Mix_Init(MIX_InitFlags.MIX_INIT_MP3 | MIX_InitFlags.MIX_INIT_OGG) < 0) throw new Exception($"SDL MIXER: {Mix_GetError()}");
            
            if (Mix_OpenAudio(44100, MIX_DEFAULT_FORMAT, 2, 2048) < 0) throw new Exception($"SDL MIXER: {Mix_GetError()}");
            
            if (TTF_Init() < 0) throw new Exception($"SDL TTF: {TTF_GetError()}");
        }
    }
}