using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    // Malloc
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_malloc(UIntPtr size);
    public static IntPtr Malloc(UIntPtr size)
    {
        return SDL_malloc(size);
    }
    
    // Free
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_free(IntPtr memory);
    public static void Free(IntPtr memory)
    {
        SDL_free(memory);
    }
}