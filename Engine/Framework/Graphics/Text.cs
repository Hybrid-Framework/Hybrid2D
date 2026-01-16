using System;

namespace Hybrid
{
    // Internal
    public sealed unsafe partial class Text
    {
        internal Font FontHandle { get; set; }
        internal Color ColorHandle { get; set; }
        internal string TextHandle { get; set; }
        internal SDL.Texture* TextureHandle { get; set; }
        
        internal Text(Font font, string text)
        {
            FontHandle = font;
            TextHandle = text;
            ColorHandle = Color.White;
            
            Rebuild(this);
        }
    }
    
    // Create & Destroy
    public sealed partial class Text
    {
        public static Text CreateText(Font font, string message)
        {
            return new Text(font, message);
        }

        public static void DestroyFont(Text text)
        {
            text.TextHandle = string.Empty;
        }
    }
    
    // Text API
    public sealed unsafe partial class Text
    {
        private static void Rebuild(Text text)
        {
            SDL.Surface* surface = SDL_ttf.RenderTextSolid(text.FontHandle.Handle, text.TextHandle, Color.ToSDLColor32(text.ColorHandle));

            if (surface != null)
            {
                if (text.TextHandle != null)
                {
                    SDL.DestroyTexture(text.TextureHandle);
                }
                
                text.TextureHandle = SDL.CreateTextureFromSurface(Graphics.Handle, surface);
            }
        
            SDL.DestroySurface(surface);
        }
    }
}