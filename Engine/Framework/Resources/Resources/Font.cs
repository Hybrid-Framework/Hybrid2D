using System;

namespace Hybrid
{
    // Font
    public unsafe class Font : Resource
    {
        internal SDL.Font* Handle { get; private set; }
        
        internal Font(SDL.Font* handle)
        {
            Handle = handle;
        }

        internal override void OnDestroy()
        {
            if (Handle != null)
            {
                SDL_ttf.CloseFont(Handle);
                Handle = null;
            }
        }
    }
}