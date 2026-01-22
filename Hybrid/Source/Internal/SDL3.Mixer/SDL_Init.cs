using System.Runtime.InteropServices;

internal static unsafe partial class SDL_mixer
{
    // Library
    private const string library = "SDL3_mixer";
    
    
    // Init
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_Init();
    internal static bool Init()
    {
        return MIX_Init();
    }
    
    // Quit
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void MIX_Quit();
    internal static void Quit()
    {
        MIX_Quit();
    }
}