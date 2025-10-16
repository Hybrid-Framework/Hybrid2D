using System.Runtime.InteropServices;

public static unsafe partial class SDL_image
{
    // Load
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr IMG_Load(byte* path);
    public static IntPtr Load(string path)
    {
        var bytes = SDL.StringToUtf8(path);

        fixed (byte* utf8 = bytes)
        {
            return IMG_Load(utf8);
        }
    }

    // Load Texture
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr IMG_LoadTexture(IntPtr renderer, byte* path);
    public static IntPtr LoadTexture(IntPtr renderer, string path)
    {
        var bytes = SDL.StringToUtf8(path);

        fixed (byte* utf8 = bytes)
        {
            return IMG_LoadTexture(renderer, utf8);
        }
    }
    
    // Save
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool IMG_Save(IntPtr surface, byte* path);
    public static bool Save(IntPtr surface, string path)
    {
        var bytes = SDL.StringToUtf8(path);

        fixed (byte* utf8 = bytes)
        {
            return IMG_Save(surface, utf8);
        }
    }
    
    // Save BMP
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool IMG_SaveBMP(IntPtr surface, byte* path);
    public static bool SaveBMP(IntPtr surface, string path)
    {
        var bytes = SDL.StringToUtf8(path);

        fixed (byte* utf8 = bytes)
        {
            return IMG_SaveBMP(surface, utf8);
        }
    }
    
    // Save PNG
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool IMG_SavePNG(IntPtr surface, byte* path);
    public static bool SavePNG(IntPtr surface, string path)
    {
        var bytes = SDL.StringToUtf8(path);

        fixed (byte* utf8 = bytes)
        {
            return IMG_SavePNG(surface, utf8);
        }
    }
    
    // Save JPG
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool IMG_SaveJPG(IntPtr surface, byte* path, int quality);
    public static bool SaveJPG(IntPtr surface, string path, int quality)
    {
        var bytes = SDL.StringToUtf8(path);

        fixed (byte* utf8 = bytes)
        {
            return IMG_SaveJPG(surface, utf8, quality);
        }
    }
    
    // Get Clipboard Image
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr IMG_GetClipboardImage();
    public static IntPtr GetClipboardImage()
    {
        return IMG_GetClipboardImage();
    }
}