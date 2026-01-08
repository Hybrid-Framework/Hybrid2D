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

    // App Iterate
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate SDL.AppResult SDL_AppIterate(IntPtr state);

    // App Event
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate SDL.AppResult SDL_AppEvent(IntPtr state, SDL.Event* evt);

    // App Quit
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void SDL_AppQuit(IntPtr state, SDL.AppResult result);
    
    // Set Main Ready
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetMainReady();
    
    // SDL Run App
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RunApp(int argc, IntPtr argv, delegate* unmanaged[Cdecl]<int, IntPtr, int> mainFunc, IntPtr reserved);
    
    // Enter App Main Callbacks
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_EnterAppMainCallbacks
    (
        int argc,
        IntPtr argv,
        delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr, SDL.AppResult> initFunc,
        delegate* unmanaged[Cdecl]<IntPtr, SDL.AppResult> iterateFunc,
        delegate* unmanaged[Cdecl]<IntPtr, SDL.Event*, SDL.AppResult> eventFunc,
        delegate* unmanaged[Cdecl]<IntPtr, SDL.AppResult, void> quitFunc
    );
}