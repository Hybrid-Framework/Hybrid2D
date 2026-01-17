using System.IO;
using System;

namespace Hybrid
{
    // Internal
    public sealed unsafe partial class Font
    {
        internal static int DefaultFontSize { get; set; } = 64;

        internal SDL.Font* FontHandle
        {
            get; set;
        }
        
        internal Font(string fontPath)
        {
            fontPath = Path.Combine(SDL.GetBasePath() + fontPath);
            {
                FontHandle = SDL_ttf.OpenFont(fontPath, DefaultFontSize);
                SDL_ttf.SetFontSDF(FontHandle, true);
            }
        }
    }
    
    // Create & Destroy
    public unsafe partial class Font
    {
        public static Font CreateFont(string fontPath)
        {
            return new Font(fontPath);
        }

        public static void DestroyFont(Font font)
        {
            if (font.FontHandle != null)
            {
                SDL_ttf.CloseFont(font.FontHandle);
                font.FontHandle = null;
            }
        }
    }

    // Font API
    public unsafe partial class Font
    {
        public static void SetFontSpacing(Font font, int spacing)
        {
            SDL_ttf.SetFontCharSpacing(font.FontHandle, spacing);
        }

        public static int GetFontSpacing(Font font)
        {
            return SDL_ttf.GetFontCharSpacing(font.FontHandle);
        }

        public static int GetFontAscent(Font font)
        {
            return SDL_ttf.GetFontAscent(font.FontHandle);
        }

        public static int GetFontDescent(Font font)
        {
            return SDL_ttf.GetFontDescent(font.FontHandle);
        }

        public static int GetFontHeight(Font font)
        {
            return SDL_ttf.GetFontHeight(font.FontHandle);
        }
    }
    
    // Text API
    public unsafe partial class Font
    {
        public static Point GetTextSize(Font font, string text, float size)
        {
            SDL_ttf.GetStringSize(font.FontHandle, text, out int w, out int h);
            {
                float scale = size / Font.DefaultFontSize;

                return new Point
                (
                    (int)(w * scale),
                    (int)(h * scale)
                );
            }
        }
        
        public static float GetTextWidth(Font font, string text, float size)
        {
            return GetTextSize(font, text, size).x;
        }
        
        public static float GetTextHeight(Font font, string text, float size)
        {
            return GetTextSize(font, text, size).y;
        }
    }
}