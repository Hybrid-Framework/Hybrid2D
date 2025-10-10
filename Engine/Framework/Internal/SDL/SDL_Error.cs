using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Get Error
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetError();
    public static string GetError()
    {
        return Utf8ToString(SDL_GetError());
    }
    
    // Clear Error
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_ClearError();
    public static void ClearError()
    {
        SDL_ClearError();
    }
    
    // Set Error
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetError(byte* error);
    public static bool SetError(string error)
    {
        var bytes = StringToUtf8(error);
        
        fixed (byte* utf8 = bytes)
        {
            return SDL_SetError(utf8);
        }
    }
}