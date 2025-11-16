using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    // Main Function
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int MainFunction(int argc, IntPtr argv);
    
    // Run App
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern int SDL_RunApp(int argc, IntPtr argv, MainFunction function, IntPtr reserved);
    public static int RunApp(int argc, IntPtr argv, MainFunction function, IntPtr reserved)
    {
        return SDL_RunApp(argc, argv, function, reserved);
    }
    
    // Set Main Ready
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_SetMainReady();
    public static void SetMainReady()
    {
        SDL_SetMainReady();
    }
}