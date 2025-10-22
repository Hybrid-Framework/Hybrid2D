using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    // Get Ticks
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern ulong SDL_GetTicks();
    public static ulong GetTicks()
    {
        return SDL_GetTicks();
    }
    
    // Get Performance Counter
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern ulong SDL_GetPerformanceCounter();
    public static ulong GetPerformanceCounter()
    {
        return SDL_GetPerformanceCounter();
    }
    
    // Get Performance Frequency
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern ulong SDL_GetPerformanceFrequency();
    public static ulong GetPerformanceFrequency()
    {
        return SDL_GetPerformanceFrequency();
    }
    
    // Delay Precise
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_DelayPrecise(ulong ns);
    public static void DelayPrecise(ulong ns)
    {
        SDL_DelayPrecise(ns);
    }
    
    // Delay
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_Delay(uint ms);
    public static void Delay(uint ms)
    {
        SDL_Delay(ms);
    }
}