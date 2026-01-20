using System.Runtime.InteropServices;
using System;

internal static unsafe partial class SDL
{
    public enum IOWhence
    {
        SDL_IO_SEEK_SET = 0,
        SDL_IO_SEEK_CUR = 1,
        SDL_IO_SEEK_END = 2,
    }
}