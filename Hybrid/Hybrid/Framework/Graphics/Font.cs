using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    // Internal
    public sealed unsafe partial class Font
    {
        internal static int DefaultSize { get; set; } = 64;
        internal SDL.IOStream* Stream { get; set; }
        internal SDL.Font* Handle { get; set; }
        internal GCHandle GCHandle;
        
        
        internal Font(string path)
        {
            // Create Stream
            Stream = Resources.CreateStream(path, out GCHandle);
            {
                // Open Font From Stream
                Handle = SDL_ttf.OpenFontIO(Stream, false, DefaultSize);
                {
                    if (Handle == null)
                    {
                        throw new Exception($"Failed to load font '{path}': {SDL.GetError()}");
                    }
                }
                
                // Apply SDF for scaling
                SDL_ttf.SetFontSDF(Handle, true);
            }
        }
    }
    
    // Font Management
    public unsafe partial class Font
    {
        // Create new font instance from file
        public static Font CreateFont(string path)
        {
            return new Font(path);
        }

        // Destroy existing font instance
        public static void DestroyFont(Font font)
        {
            if (font.Handle != null)
            {
                SDL_ttf.CloseFont(font.Handle);
                font.Handle = null;
            }

            if (font.GCHandle.IsAllocated)
            {
                font.GCHandle.Free();
            }

            if (font.Stream != null)
            {
                SDL.CloseIO(font.Stream);
            }
        }
    }

    // Font
    public unsafe partial class Font
    {
        // Set font character spacing
        public static void SetSpacing(Font font, int spacing)
        {
            SDL_ttf.SetFontCharSpacing(font.Handle, spacing);
        }

        // Get font character spacing
        public static int GetSpacing(Font font)
        {
            return SDL_ttf.GetFontCharSpacing(font.Handle);
        }

        // Get font ascent
        public static int GetAscent(Font font)
        {
            return SDL_ttf.GetFontAscent(font.Handle);
        }

        // Get font descent
        public static int GetDescent(Font font)
        {
            return SDL_ttf.GetFontDescent(font.Handle);
        }

        // Get font height
        public static int GetHeight(Font font)
        {
            return SDL_ttf.GetFontHeight(font.Handle);
        }
    }
}