using System.Runtime.InteropServices;

public static unsafe partial class SDL_image
{
    // Load Texture
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr IMG_LoadTexture(IntPtr renderer, byte* file);
    public static IntPtr LoadTexture(IntPtr renderer, string file)
    {
        var bytes = SDL.StringToUtf8(file);

        fixed (byte* utf8 = bytes)
        {
            return IMG_LoadTexture(renderer, utf8);
        }
    }
    
    // Load
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr IMG_Load(IntPtr renderer, byte* file);
    public static IntPtr Load(IntPtr renderer, string file)
    {
        var bytes = SDL.StringToUtf8(file);

        fixed (byte* utf8 = bytes)
        {
            return IMG_Load(renderer, utf8);
        }
    }
    
    // Save
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool IMG_Save(IntPtr surface, byte* file);
    public static bool Save(IntPtr surface, string file)
    {
        var bytes = SDL.StringToUtf8(file);

        fixed (byte* utf8 = bytes)
        {
            return IMG_Save(surface, utf8);
        }
    }
}