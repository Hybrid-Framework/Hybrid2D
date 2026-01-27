using System.Runtime.InteropServices;
using System;

internal static unsafe partial class SDL_ttf
{
    // Render Text Solid
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Surface* TTF_RenderText_Solid(SDL.Font* font, byte* text, UIntPtr size, SDL.Color32 color);
    public static SDL.Surface* RenderTextSolid(SDL.Font* font, string text, SDL.Color32 color)
    {
        var bytes = SDL.StringToUtf8(text);

        fixed (byte* utf8 = bytes)
        {
            UIntPtr size = (UIntPtr)(bytes.Length - 1);
            return TTF_RenderText_Solid(font, utf8, size, color);
        }
    }
    
    // Render Text Solid Wrapped
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Surface* TTF_RenderText_Solid_Wrapped(SDL.Font* font, byte* text, UIntPtr size, SDL.Color32 color, int wrapLength);
    public static SDL.Surface* RenderTextSolidWrapped(SDL.Font* font, string text, SDL.Color32 color, int wrapLength)
    {
        var bytes = SDL.StringToUtf8(text);

        fixed (byte* utf8 = bytes)
        {
            UIntPtr size = (UIntPtr)(bytes.Length - 1);
            return TTF_RenderText_Solid_Wrapped(font, utf8, size, color, wrapLength);
        }
    }
    
    // Render Text Shaded
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Surface* TTF_RenderText_Shaded(SDL.Font* font, byte* text, UIntPtr size, SDL.Color32 foreground, SDL.Color32 background);
    public static SDL.Surface* RenderTextShaded(SDL.Font* font, string text, SDL.Color32 foreground, SDL.Color32 background)
    {
        var bytes = SDL.StringToUtf8(text);

        fixed (byte* utf8 = bytes)
        {
            UIntPtr size = (UIntPtr)(bytes.Length - 1);
            return TTF_RenderText_Shaded(font, utf8, size, foreground, background);
        }
    }
    
    // Render Text Shaded Wrapped
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Surface* TTF_RenderText_Shaded_Wrapped(SDL.Font* font, byte* text, UIntPtr size, SDL.Color32 foreground, SDL.Color32 background, int wrapWidth);
    public static SDL.Surface* RenderTextShadedWrapped(SDL.Font* font, string text, SDL.Color32 foreground, SDL.Color32 background, int wrapWidth)
    {
        var bytes = SDL.StringToUtf8(text);

        fixed (byte* utf8 = bytes)
        {
            UIntPtr size = (UIntPtr)(bytes.Length - 1);
            return TTF_RenderText_Shaded_Wrapped(font, utf8, size, foreground, background, wrapWidth);
        }
    }
    
    // Render Text Blended
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Surface* TTF_RenderText_Blended(SDL.Font* font, byte* text, UIntPtr size, SDL.Color32 color);
    public static SDL.Surface* RenderTextBlended(SDL.Font* font, string text, SDL.Color32 color)
    {
        var bytes = SDL.StringToUtf8(text);

        fixed (byte* utf8 = bytes)
        {
            UIntPtr size = (UIntPtr)(bytes.Length - 1);
            return TTF_RenderText_Blended(font, utf8, size, color);
        }
    }
    
    // Render Text Blended Wrapped
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Surface* TTF_RenderText_Blended_Wrapped(SDL.Font* font, byte* text, UIntPtr size, SDL.Color32 color, int wrapWidth);
    public static SDL.Surface* RenderTextBlendedWrapped(SDL.Font* font, string text, SDL.Color32 color, int wrapWidth)
    {
        var bytes = SDL.StringToUtf8(text);

        fixed (byte* utf8 = bytes)
        {
            UIntPtr size = (UIntPtr)(bytes.Length - 1);
            return TTF_RenderText_Blended_Wrapped(font, utf8, size, color, wrapWidth);
        }
    }
    
    // Render Text LCD
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Surface* TTF_RenderText_LCD(SDL.Font* font, byte* text, UIntPtr size, SDL.Color32 foreground, SDL.Color32 background);
    public static SDL.Surface* RenderTextLCD(SDL.Font* font, string text, SDL.Color32 foreground, SDL.Color32 background)
    {
        var bytes = SDL.StringToUtf8(text);

        fixed (byte* utf8 = bytes)
        {
            UIntPtr size = (UIntPtr)(bytes.Length - 1);
            return TTF_RenderText_LCD(font, utf8, size, foreground, background);
        }
    }
    
    // Render Text LCD Wrapped
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Surface* TTF_RenderText_LCD_Wrapped(SDL.Font* font, byte* text, UIntPtr size, SDL.Color32 foreground, SDL.Color32 background, int wrapWidth);
    public static SDL.Surface* RenderTextLCDWrapped(SDL.Font* font, string text, SDL.Color32 foreground, SDL.Color32 background, int wrapWidth)
    {
        var bytes = SDL.StringToUtf8(text);

        fixed (byte* utf8 = bytes)
        {
            UIntPtr size = (UIntPtr)(bytes.Length - 1);
            return TTF_RenderText_LCD_Wrapped(font, utf8, size, foreground, background, wrapWidth);
        }
    }
}