using System.Runtime.InteropServices;

internal static unsafe partial class SDL_mixer
{
    // Init
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool MIX_Init();
    public static bool Init()
    {
        return MIX_Init();
    }
    
    // Quit
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void MIX_Quit();
    public static void Quit()
    {
        MIX_Quit();
    }
}