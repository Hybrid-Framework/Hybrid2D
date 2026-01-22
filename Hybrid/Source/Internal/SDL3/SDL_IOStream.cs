using System.Runtime.InteropServices;
using System;

internal static unsafe partial class SDL
{
    // Open IO
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IOStream* SDL_IOFromMem(void* mem, nuint size);
    internal static IOStream* OpenIO(void* memory, nuint size)
    {
        return SDL_IOFromMem(memory, size);
    }
    
    // Close IO
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_CloseIO(SDL.IOStream* stream);
    internal static bool CloseIO(SDL.IOStream* stream)
    {
        return SDL_CloseIO(stream);
    }
}