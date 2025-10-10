using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Mouse Support
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_HasMouse();
    public static bool MouseSupport()
    {
        return SDL_HasMouse();
    }
    
    // Show Cursor
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_ShowCursor();
    public static void ShowCursor()
    {
        SDL_ShowCursor();
    }
    
    // Hide Cursor
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_HideCursor();
    public static void HideCursor()
    {
        SDL_HideCursor();
    }
    
    // Cursor Visible
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_CursorVisible();
    public static bool CursorVisible()
    {
        return SDL_CursorVisible();
    }
    
    // Get Mouse Name From ID
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetMouseNameForID(int id);
    public static string GetMouseNameFromID(int id)
    {
        return Utf8ToString(SDL_GetMouseNameForID(id));
    }
    
    // Get Mice
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern int* SDL_GetMice(out int count);
    public static int[] GetMouseDevices()
    {
        int* ptr = SDL_GetMice(out int count);

        if (ptr == null || count == 0)
        {
            return Array.Empty<int>();
        }

        int[] ids = new int[count];

        for (int i = 0; i < count; i++)
        {
            ids[i] = ptr[i];
        }

        SDL.Free((IntPtr)ptr);
        return ids;
    }
}