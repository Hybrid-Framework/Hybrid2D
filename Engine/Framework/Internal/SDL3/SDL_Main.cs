using System.Runtime.InteropServices;
using System;

internal static unsafe partial class SDL
{
    // Main Function
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int MainFunction(int argc, IntPtr argv);
    
    // App Init
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate SDL.AppResult SDL_AppInit(IntPtr state, int argc, IntPtr argv);

    // App Event
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate SDL.AppResult SDL_AppEvent(IntPtr state, SDL.Event* evt);

    // App Quit
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void SDL_AppQuit(IntPtr state, SDL.AppResult result);
    
    // App Iterate
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate SDL.AppResult SDL_AppIterate(IntPtr state);

    // Enter App Main Callbacks
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern int SDL_EnterAppMainCallbacks(int argc, IntPtr argv, delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr, SDL.AppResult> init, delegate* unmanaged[Cdecl]<IntPtr, SDL.AppResult> iterate, delegate* unmanaged[Cdecl]<IntPtr, SDL.Event*, SDL.AppResult> events, delegate* unmanaged[Cdecl]<IntPtr, SDL.AppResult, void> quit);
    public static int EnterAppMainCallbacks(int argc, IntPtr argv, delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr, SDL.AppResult> init, delegate* unmanaged[Cdecl]<IntPtr, SDL.AppResult> iterate, delegate* unmanaged[Cdecl]<IntPtr, SDL.Event*, SDL.AppResult> events, delegate* unmanaged[Cdecl]<IntPtr, SDL.AppResult, void> quit)
    {
        return SDL_EnterAppMainCallbacks(argc, argv, init, iterate, events, quit);
    }
    
    // SDL Run App
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern int SDL_RunApp(int argc, IntPtr argv, delegate* unmanaged[Cdecl]<int, IntPtr, int> main, IntPtr reserved);
    public static int RunApp(int argc, IntPtr argv, delegate* unmanaged[Cdecl]<int, IntPtr, int> main, IntPtr reserved)
    {
        return SDL_RunApp(argc, argv, main, reserved);
    }
    
    // Set Main Ready
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_SetMainReady();
    public static void SetMainReady()
    {
        SDL_SetMainReady();
    }
}