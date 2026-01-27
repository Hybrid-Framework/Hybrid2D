using System.Runtime.InteropServices;
using System;

internal static unsafe partial class SDL_image
{
    // Load
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Surface* IMG_Load(byte* path);
    public static SDL.Surface* Load(string path)
    {
        var bytes = SDL.StringToUtf8(path);

        fixed (byte* utf8 = bytes)
        {
            return IMG_Load(utf8);
        }
    }

    // Load Texture
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Texture* IMG_LoadTexture(SDL.Renderer* renderer, byte* path);
    public static SDL.Texture* LoadTexture(SDL.Renderer* renderer, string path)
    {
        var bytes = SDL.StringToUtf8(path);

        fixed (byte* utf8 = bytes)
        {
            return IMG_LoadTexture(renderer, utf8);
        }
    }
    
    // Save
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool IMG_Save(SDL.Surface* surface, byte* path);
    public static bool Save(SDL.Surface* surface, string path)
    {
        var bytes = SDL.StringToUtf8(path);

        fixed (byte* utf8 = bytes)
        {
            return IMG_Save(surface, utf8);
        }
    }
    
    // Save BMP
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool IMG_SaveBMP(SDL.Surface* surface, byte* path);
    public static bool SaveBMP(SDL.Surface* surface, string path)
    {
        var bytes = SDL.StringToUtf8(path);

        fixed (byte* utf8 = bytes)
        {
            return IMG_SaveBMP(surface, utf8);
        }
    }
    
    // Save PNG
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool IMG_SavePNG(SDL.Surface* surface, byte* path);
    public static bool SavePNG(SDL.Surface* surface, string path)
    {
        var bytes = SDL.StringToUtf8(path);

        fixed (byte* utf8 = bytes)
        {
            return IMG_SavePNG(surface, utf8);
        }
    }
    
    // Save JPG
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool IMG_SaveJPG(SDL.Surface* surface, byte* path, int quality);
    public static bool SaveJPG(SDL.Surface* surface, string path, int quality)
    {
        var bytes = SDL.StringToUtf8(path);

        fixed (byte* utf8 = bytes)
        {
            return IMG_SaveJPG(surface, utf8, quality);
        }
    }
    
    // Get Clipboard Image
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Surface* IMG_GetClipboardImage();
    public static SDL.Surface* GetClipboardImage()
    {
        return IMG_GetClipboardImage();
    }
}