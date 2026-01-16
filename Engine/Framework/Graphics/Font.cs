using System.IO;
using System;

namespace Hybrid
{
    // Internal
    public sealed unsafe partial class Font
    {
        internal SDL.Font* Handle { get; set; }
        

        internal Font(string path)
        {
            path = Path.Combine(SDL.GetBasePath() + path);
            {
                Handle = SDL_ttf.OpenFont(path, 32);
            
                // Invalid Font
                if (Handle == null)
                {
                    throw new Exception($"Failed to create font '{path}'");
                }
                
                SDL_ttf.SetFontSDF(Handle, true);
            }
        }
    }

    // Create & Destroy
    public unsafe partial class Font
    {
        public static Font CreateFont(string path)
        {
            return new Font(path);
        }

        public static void DestroyFont(Font font)
        {
            if (font.Handle != null)
            {
                SDL_ttf.CloseFont(font.Handle);
                font.Handle = null;
            }
        }
    }
}