using System.Runtime.InteropServices;
using System;

internal static unsafe partial class SDL
{
    // Malloc
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_malloc(UIntPtr size);
    internal static IntPtr Malloc(UIntPtr size)
    {
        return SDL_malloc(size);
    }
    
    // Free
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_free(IntPtr memory);
    internal static void Free(IntPtr memory)
    {
        SDL_free(memory);
    }
}