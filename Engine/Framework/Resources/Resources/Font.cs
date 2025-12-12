using System;

namespace Hybrid
{
    // Internal
    public unsafe partial class Font : Resource
    {
        // SDL Font Handle
        internal SDL.Font* Handle
        {
            private set;
            get;
        }
        
        
        internal override void OnDispose()
        {
            if (Handle != null)
            {
                SDL_ttf.CloseFont(Handle);
                Handle = null;
            }
            
            base.OnDispose();
        }
    }

    // Font API
    public unsafe partial class Font
    {
        internal Font(SDL.Font* handle)
        {
            Handle = handle;
        }
    }
}