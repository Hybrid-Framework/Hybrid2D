using System.Runtime.InteropServices;

internal static unsafe partial class SDL_ttf
{
    // Library
    private const string library = "SDL3_ttf";
    
    
    // Init
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool TTF_Init();
    internal static bool Init()
    {
        return TTF_Init();
    }
    
    // Quit
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void TTF_Quit();
    internal static void Quit()
    {
        TTF_Quit();
    }
}