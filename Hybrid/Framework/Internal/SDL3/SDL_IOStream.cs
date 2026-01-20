using System.Runtime.InteropServices;
using System;

internal static unsafe partial class SDL
{
    // Open IO
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.IOStream* SDL_OpenIO(ref SDL.IOStreamInterface IOStreamInterface, IntPtr data);
    internal static SDL.IOStream* OpenIO(ref SDL.IOStreamInterface IOStreamInterface, IntPtr data)
    {
        return SDL_OpenIO(ref IOStreamInterface, data);
    }

    // Close IO
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_CloseIO(SDL.IOStream* context);
    internal static bool CloseIO(SDL.IOStream* context)
    {
        return SDL_CloseIO(context);
    }
    
    // Seek IO
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern long SDL_SeekIO(SDL.IOStream* stream, long offset, SDL.IOWhence whence);
    internal static long SeekIO(SDL.IOStream* stream, long offset, SDL.IOWhence whence)
    {
        return SDL_SeekIO(stream, offset, whence);
    }
}