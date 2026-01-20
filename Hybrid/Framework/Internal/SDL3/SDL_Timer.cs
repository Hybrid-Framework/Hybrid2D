using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    // Get Ticks
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern ulong SDL_GetTicks();
    internal static long GetTicks()
    {
        return (long)SDL_GetTicks();
    }
    
    // Get Performance Counter
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern ulong SDL_GetPerformanceCounter();
    internal static long GetPerformanceCounter()
    {
        return (long)SDL_GetPerformanceCounter();
    }
    
    // Get Performance Frequency
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern ulong SDL_GetPerformanceFrequency();
    internal static long GetPerformanceFrequency()
    {
        return (long)SDL_GetPerformanceFrequency();
    }
    
    // Delay Precise
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_DelayPrecise(ulong ns);
    internal static void DelayPrecise(ulong ns)
    {
        SDL_DelayPrecise(ns);
    }
    
    // Delay
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_Delay(uint ms);
    internal static void Delay(uint ms)
    {
        SDL_Delay(ms);
    }
}