using System.Runtime.InteropServices;
using System;

internal static unsafe partial class SDL
{
    // Store (Prevent GC)
    private static SDL_AppIterate StoredIterate;
    private static SDL_AppEvent StoredEvent;
    private static SDL_AppInit StoredInit;
    private static SDL_AppQuit StoredQuit;
    
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
    
    // Enter App Main Callbacks
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern int SDL_EnterAppMainCallbacks(int argc, IntPtr argv, SDL_AppInit initFunc, SDL_AppIterate iterateFunc, SDL_AppEvent eventFunc, SDL_AppQuit quitFunc);
    public static int EnterAppMainCallbacks(int argc, IntPtr argv, SDL_AppInit initFunc, SDL_AppIterate iterateFunc, SDL_AppEvent eventFunc, SDL_AppQuit quitFunc)
    {
        StoredIterate = iterateFunc;
        StoredEvent = eventFunc;
        StoredInit = initFunc;
        StoredQuit = quitFunc;
        
        return SDL_EnterAppMainCallbacks(argc, argv, initFunc, iterateFunc, eventFunc, quitFunc);
    }
    
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