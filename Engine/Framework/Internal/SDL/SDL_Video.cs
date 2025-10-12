using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Create Window
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_CreateWindow(byte* title, int w, int h, SDL.WindowFlags flags);
    public static IntPtr CreateWindow(string title, int w, int h, SDL.WindowFlags flags)
    {
        var bytes = StringToUtf8(title);

        fixed (byte* utf8 = bytes)
        {
            return SDL_CreateWindow(utf8, w, h, flags);
        }
    }
    
    // Destroy Window
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_DestroyWindow(IntPtr window);
    public static void DestroyWindow(IntPtr window)
    {
        SDL_DestroyWindow(window);
    }
}