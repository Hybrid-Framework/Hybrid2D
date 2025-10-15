using System.Runtime.InteropServices;

public static unsafe partial class SDL_ttf
{
    // Open Font
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr TTF_OpenFont(byte* path, float size);
    public static IntPtr OpenFont(string path, float size)
    {
        var bytes = SDL.StringToUtf8(path);

        fixed (byte* utf8 = bytes)
        {
            return TTF_OpenFont(utf8, size);
        }
    }
    
    // Close Font
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void TTF_CloseFont(IntPtr font);
    public static void CloseFont(IntPtr font)
    {
        TTF_CloseFont(font);
    }
    
    // Add Fallback Font
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool TTF_AddFallbackFont(IntPtr font, IntPtr fallback);
    public static bool AddFallbackFont(IntPtr font, IntPtr fallback)
    {
        return TTF_AddFallbackFont(font, fallback);
    }
    
    // Remove Fallback Font
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void TTF_RemoveFallbackFont(IntPtr font, IntPtr fallback);
    public static void RemoveFallbackFont(IntPtr font, IntPtr fallback)
    {
        TTF_RemoveFallbackFont(font, fallback);
    }
    
    // Clear Fallback Fonts
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void TTF_ClearFallbackFonts(IntPtr font);
    public static void ClearFallbackFonts(IntPtr font)
    {
        TTF_ClearFallbackFonts(font);
    }
    
    // Set Font Size
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool TTF_SetFontSize(IntPtr font, float size);
    public static bool SetFontSize(IntPtr font, float size)
    {
        return TTF_SetFontSize(font, size);
    }
    
    // Get Font Size
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern float TTF_GetFontSize(IntPtr font);
    public static float GetFontSize(IntPtr font)
    {
        return TTF_GetFontSize(font);
    }
    
    // Get Font Height
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern int TTF_GetFontHeight(IntPtr font);
    public static int GetFontHeight(IntPtr font)
    {
        return TTF_GetFontHeight(font);
    }
    
    // Get Font Ascent
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern int TTF_GetFontAscent(IntPtr font);
    public static int GetFontAscent(IntPtr font)
    {
        return TTF_GetFontAscent(font);
    }
    
    // Get Font Descent
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern int TTF_GetFontDescent(IntPtr font);
    public static int GetFontDescent(IntPtr font)
    {
        return TTF_GetFontDescent(font);
    }
    
    // Render Text Solid
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr TTF_RenderText_Solid(IntPtr font, byte* text, UIntPtr size, SDL.Color color);
    public static IntPtr RenderTextSolid(IntPtr font, string text, SDL.Color color)
    {
        var bytes = SDL.StringToUtf8(text);

        fixed (byte* utf8 = bytes)
        {
            return TTF_RenderText_Solid(font, utf8, (UIntPtr)(bytes.Length - 1), color);
        }
    }
    
    // Render Text Shaded
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr TTF_RenderText_Shaded(IntPtr font, byte* text, UIntPtr size, SDL.Color foreground, SDL.Color background);
    public static IntPtr RenderTextShaded(IntPtr font, string text, SDL.Color foreground, SDL.Color background)
    {
        var bytes = SDL.StringToUtf8(text);

        fixed (byte* utf8 = bytes)
        {
            return TTF_RenderText_Shaded(font, utf8, (UIntPtr)(bytes.Length - 1), foreground, background);
        }
    }
    
    // Render Text Blended
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr TTF_RenderText_Blended(IntPtr font, byte* text, UIntPtr size, SDL.Color color);
    public static IntPtr RenderTextBlended(IntPtr font, string text, SDL.Color color)
    {
        var bytes = SDL.StringToUtf8(text);

        fixed (byte* utf8 = bytes)
        {
            return TTF_RenderText_Blended(font, utf8, (UIntPtr)(bytes.Length - 1), color);
        }
    }
    
    // Render Text LCD
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr TTF_RenderText_LCD(IntPtr font, byte* text, UIntPtr size, SDL.Color foreground, SDL.Color background);
    public static IntPtr RenderTextLCD(IntPtr font, string text, SDL.Color foreground, SDL.Color background)
    {
        var bytes = SDL.StringToUtf8(text);

        fixed (byte* utf8 = bytes)
        {
            return TTF_RenderText_LCD(font, utf8, (UIntPtr)(bytes.Length - 1), foreground, background);
        }
    }
}