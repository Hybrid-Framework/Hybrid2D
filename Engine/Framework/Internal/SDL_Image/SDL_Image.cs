using System.Runtime.InteropServices;

public static unsafe partial class SDL_image
{
    // Load Texture
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr IMG_LoadTexture(IntPtr renderer, byte* path);
    public static IntPtr LoadTexture(string path)
    {
        var bytes = SDL.StringToUtf8(path);

        fixed (byte* utf8 = bytes)
        {
            return IMG_LoadTexture(SDL.GetRenderer(), utf8);
        }
    }
    
    // Save Texture
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool IMG_Save(IntPtr surface, byte* path);
    public static void SaveTexture(IntPtr texture, string path)
    {
        IntPtr surface = SDL.CreateSurfaceFromTexture(texture);
        var bytes = SDL.StringToUtf8(path);

        fixed (byte* utf8 = bytes)
        {
            IMG_Save(surface, utf8);
        }
        
        SDL.DestroySurface(surface);
    }
}