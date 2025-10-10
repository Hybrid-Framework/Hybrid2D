using System.Runtime.InteropServices;

public static unsafe partial class SDL_image
{
    // Library
    private const string library = "SDL3_image";
    
    
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
    public static IntPtr LoadTexture(string path)
    {
        var bytes = SDL.StringToUtf8(path);

        fixed (byte* utf8 = bytes)
        {
            return IMG_LoadTexture(SDL.GetRenderer(), utf8);
        }
    }
}