using System.Runtime.InteropServices;

internal static unsafe partial class SDL_ttf
{
    // Init
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool TTF_Init();
    public static bool Init()
    {
        return TTF_Init();
    }
    
    // Quit
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void TTF_Quit();
    public static void Quit()
    {
        TTF_Quit();
    }
}