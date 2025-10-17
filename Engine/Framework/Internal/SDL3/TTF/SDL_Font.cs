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
    
    // Copy Font
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr TTF_CopyFont(IntPtr font);
    public static IntPtr CopyFont(IntPtr font)
    {
        return TTF_CopyFont(font);
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
    
    // Set Font Size DPI
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool TTF_SetFontSizeDPI(IntPtr font, float size, int horizontalDPI, int verticalDPI);
    public static bool SetFontSizeDPI(IntPtr font, float size, int horizontalDPI, int verticalDPI)
    {
        return TTF_SetFontSizeDPI(font, size, horizontalDPI, verticalDPI);
    }
    
    // Get Font Size DPI
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool TTF_GetFontDPI(IntPtr font, out int horizontalDPI, out int verticalDPI);
    public static bool GetFontSizeDPI(IntPtr font, out int horizontalDPI, out int verticalDPI)
    {
        return TTF_GetFontDPI(font, out horizontalDPI, out verticalDPI);
    }
    
    // Set Font Style
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void TTF_SetFontStyle(IntPtr font, FontStyleFlags style);
    public static void SetFontStyle(IntPtr font, FontStyleFlags style)
    {
        TTF_SetFontStyle(font, style);
    }
    
    // Get Font Style
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern FontStyleFlags TTF_GetFontStyle(IntPtr font);
    public static FontStyleFlags GetFontStyle(IntPtr font)
    {
        return TTF_GetFontStyle(font);
    }
    
    // Set Font Outline
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool TTF_SetFontOutline(IntPtr font, int outline);
    public static bool SetFontOutline(IntPtr font, int outline)
    {
        return TTF_SetFontOutline(font, outline);
    }
    
    // Get Font Outline
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern int TTF_GetFontOutline(IntPtr font);
    public static int GetFontOutline(IntPtr font)
    {
        return TTF_GetFontOutline(font);
    }
    
    // Set Font Hinting
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void TTF_SetFontHinting(IntPtr font, HintingFlags flags);
    public static void SetFontHinting(IntPtr font, HintingFlags flags)
    {
        TTF_SetFontHinting(font, flags);
    }
    
    // Get Font Hinting
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern HintingFlags TTF_GetFontHinting(IntPtr font);
    public static HintingFlags GetFontHinting(IntPtr font)
    {
        return TTF_GetFontHinting(font);
    }
    
    // Set Font SDF
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool TTF_SetFontSDF(IntPtr font, SDL.Bool enabled);
    public static bool SetFontSDF(IntPtr font, bool enabled)
    {
        return TTF_SetFontSDF(font, enabled);
    }
    
    // Get Font SDF
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool TTF_GetFontSDF(IntPtr font);
    public static bool GetFontSDF(IntPtr font)
    {
        return TTF_GetFontSDF(font);
    }
    
    // Get Font Weight
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern int TTF_GetFontWeight(IntPtr font);
    public static FontWeight GetFontWeight(IntPtr font)
    {
        return (FontWeight)TTF_GetFontWeight(font);
    }
    
    // Get Num Font Faces
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern int TTF_GetNumFontFaces(IntPtr font);
    public static int GetNumFontFaces(IntPtr font)
    {
        return TTF_GetNumFontFaces(font);
    }
    
    // Set Font Wrap Alignment
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void TTF_SetFontWrapAlignment(IntPtr font, HorizontalAlignment alignment);
    public static void SetFontWrapAlignment(IntPtr font, HorizontalAlignment alignment)
    {
        TTF_SetFontWrapAlignment(font, alignment);
    }
    
    // Get Font Wrap Alignment
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern HorizontalAlignment TTF_GetFontWrapAlignment(IntPtr font);
    public static HorizontalAlignment GetFontWrapAlignment(IntPtr font)
    {
        return TTF_GetFontWrapAlignment(font);
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
    
    // Set Font Line Skip
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void TTF_SetFontLineSkip(IntPtr font, int lineSkip);
    public static void SetFontLineSkip(IntPtr font, int lineSkip)
    {
        TTF_SetFontLineSkip(font, lineSkip);
    }
    
    // Get Font Line Skip
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern int TTF_GetFontLineSkip(IntPtr font);
    public static int GetFontLineSkip(IntPtr font)
    {
        return TTF_GetFontLineSkip(font);
    }
    
    // Set Font Kerning
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void TTF_SetFontKerning(IntPtr font, SDL.Bool enabled);
    public static void SetFontKerning(IntPtr font, bool enabled)
    {
        TTF_SetFontKerning(font, enabled);
    }
    
    // Get Font Kerning
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool TTF_GetFontKerning(IntPtr font);
    public static bool GetFontKerning(IntPtr font)
    {
        return TTF_GetFontKerning(font);
    }
    
    // Font Is Fixed Width
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool TTF_FontIsFixedWidth(IntPtr font);
    public static bool FontIsFixedWidth(IntPtr font)
    {
        return TTF_FontIsFixedWidth(font);
    }
    
    // Font Is Scalable
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool TTF_FontIsScalable(IntPtr font);
    public static bool FontIsScalable(IntPtr font)
    {
        return TTF_FontIsScalable(font);
    }
    
    // Get Font Family Name
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern byte* TTF_GetFontFamilyName(IntPtr font);
    public static string GetFontFamilyName(IntPtr font)
    {
        return SDL.Utf8ToString(TTF_GetFontFamilyName(font));
    }
    
    // Get Font Style Name
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern byte* TTF_GetFontStyleName(IntPtr font);
    public static string GetFontStyleName(IntPtr font)
    {
        return SDL.Utf8ToString(TTF_GetFontStyleName(font));
    }
    
    // Set Font Direction
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool TTF_SetFontDirection(IntPtr font, Direction direction);
    public static bool SetFontDirection(IntPtr font, Direction direction)
    {
        return TTF_SetFontDirection(font, direction);
    }
    
    // Get Font Direction
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern Direction TTF_GetFontDirection(IntPtr font);
    public static Direction GetFontDirection(IntPtr font)
    {
        return TTF_GetFontDirection(font);
    }
    
    // Set Font Char Spacing
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool TTF_SetFontCharSpacing(IntPtr font, int spacing);
    public static bool SetFontCharSpacing(IntPtr font, int spacing)
    {
        return TTF_SetFontCharSpacing(font, spacing);
    }
    
    // Get Font Char Spacing
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern int TTF_GetFontCharSpacing(IntPtr font);
    public static int GetFontCharSpacing(IntPtr font)
    {
        return TTF_GetFontCharSpacing(font);
    }
    
    // Get String Size
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool TTF_GetStringSize(IntPtr font, byte* text, UIntPtr size, out int w, out int h);
    public static bool GetStringSize(IntPtr font, string text, out int w, out int h)
    {
        var bytes = SDL.StringToUtf8(text);

        fixed (byte* utf8 = bytes)
        {
            UIntPtr size = (UIntPtr)(bytes.Length - 1);
            return TTF_GetStringSize(font, utf8, size, out w, out h);
        }
    }
    
    // Get String Size Wrapped
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool TTF_GetStringSizeWrapped(IntPtr font, byte* text, UIntPtr size, int wrapWidth, out int w, out int h);
    public static bool GetStringSizeWrapped(IntPtr font, string text, int wrapWidth, out int w, out int h)
    {
        var bytes = SDL.StringToUtf8(text);

        fixed (byte* utf8 = bytes)
        {
            UIntPtr size = (UIntPtr)(bytes.Length - 1);
            return TTF_GetStringSizeWrapped(font, utf8, size, wrapWidth, out w, out h);
        }
    }
    
    // Measure String
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool TTF_MeasureString(IntPtr font, byte* text, UIntPtr size, int maxWidth, out int width, out UIntPtr length);
    public static bool MeasureString(IntPtr font, string text, int maxWidth, out int width, out UIntPtr length)
    {
        var bytes = SDL.StringToUtf8(text);

        fixed (byte* utf8 = bytes)
        {
            UIntPtr size = (UIntPtr)(bytes.Length - 1);
            return TTF_MeasureString(font, utf8, size, maxWidth, out width, out length);
        }
    }
}