using System.Runtime.InteropServices;

public static unsafe partial class SDL_ttf
{
    // Render Text Solid
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr TTF_RenderText_Solid(IntPtr font, byte* text, UIntPtr size, SDL.Color color);
    public static IntPtr RenderTextSolid(IntPtr font, string text, SDL.Color color)
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
    private static extern IntPtr TTF_RenderText_Solid_Wrapped(IntPtr font, byte* text, UIntPtr size, SDL.Color color, int wrapLength);
    public static IntPtr RenderTextSolidWrapped(IntPtr font, string text, SDL.Color color, int wrapLength)
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
    private static extern IntPtr TTF_RenderText_Shaded(IntPtr font, byte* text, UIntPtr size, SDL.Color foreground, SDL.Color background);
    public static IntPtr RenderTextShaded(IntPtr font, string text, SDL.Color foreground, SDL.Color background)
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
    private static extern IntPtr TTF_RenderText_Shaded_Wrapped(IntPtr font, byte* text, UIntPtr size, SDL.Color foreground, SDL.Color background, int wrapWidth);
    public static IntPtr RenderTextShadedWrapped(IntPtr font, string text, SDL.Color foreground, SDL.Color background, int wrapWidth)
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
    private static extern IntPtr TTF_RenderText_Blended(IntPtr font, byte* text, UIntPtr size, SDL.Color color);
    public static IntPtr RenderTextBlended(IntPtr font, string text, SDL.Color color)
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
    private static extern IntPtr TTF_RenderText_Blended_Wrapped(IntPtr font, byte* text, UIntPtr size, SDL.Color color, int wrapWidth);
    public static IntPtr RenderTextBlendedWrapped(IntPtr font, string text, SDL.Color color, int wrapWidth)
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
    private static extern IntPtr TTF_RenderText_LCD(IntPtr font, byte* text, UIntPtr size, SDL.Color foreground, SDL.Color background);
    public static IntPtr RenderTextLCD(IntPtr font, string text, SDL.Color foreground, SDL.Color background)
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
    private static extern IntPtr TTF_RenderText_LCD_Wrapped(IntPtr font, byte* text, UIntPtr size, SDL.Color foreground, SDL.Color background, int wrapWidth);
    public static IntPtr RenderTextLCDWrapped(IntPtr font, string text, SDL.Color foreground, SDL.Color background, int wrapWidth)
    {
        var bytes = SDL.StringToUtf8(text);

        fixed (byte* utf8 = bytes)
        {
            UIntPtr size = (UIntPtr)(bytes.Length - 1);
            return TTF_RenderText_LCD_Wrapped(font, utf8, size, foreground, background, wrapWidth);
        }
    }
}