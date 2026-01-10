using System.Runtime.InteropServices;
using System;
using Hybrid;

internal static unsafe partial class SDL
{
    // Get Primary Display
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern uint SDL_GetPrimaryDisplay();
    public static uint GetPrimaryDisplay()
    {
        return SDL_GetPrimaryDisplay();
    }
    
    // Get Display For Window
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern uint SDL_GetDisplayForWindow(SDL.Window* window);
    public static uint GetDisplayForWindow(SDL.Window* window)
    {
        return SDL_GetDisplayForWindow(window);
    }
    
    // Get Display Title
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern byte* SDL_GetDisplayName(uint displayID);
    public static string GetDisplayName(uint displayID)
    {
        return Utf8ToString(SDL_GetDisplayName(displayID));
    }
    
    // Get Natural Display Orientation
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Orientation SDL_GetNaturalDisplayOrientation(uint displayID);
    public static SDL.Orientation GetNaturalDisplayOrientation(uint displayID)
    {
        return SDL_GetNaturalDisplayOrientation(displayID);
    }
    
    // Get Current Display Orientation
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Orientation SDL_GetCurrentDisplayOrientation(uint displayID);
    public static SDL.Orientation GetCurrentDisplayOrientation(uint displayID)
    {
        return SDL_GetCurrentDisplayOrientation(displayID);
    }
    
    // Get Display Bounds
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetDisplayBounds(uint displayID, out RectInt rect);
    public static bool GetDisplayBounds(uint displayID, out RectInt rect)
    {
        return SDL_GetDisplayBounds(displayID, out rect);
    }
    
    // Get Displays
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetDisplays(out int count);
    public static uint[] GetDisplays(out int count)
    {
        IntPtr ptr = SDL_GetDisplays(out count);

        if (ptr == IntPtr.Zero || count == 0)
        {
            return Array.Empty<uint>();
        }

        uint[] ids = new uint[count];
        Marshal.Copy(ptr, (int[])(object)ids, 0, count);
        SDL_free(ptr);
        return ids;
    }
}