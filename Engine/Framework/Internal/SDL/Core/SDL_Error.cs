using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Get Error
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetError();
    public static string GetError()
    {
        return PtrToString(SDL_GetError());
    }
    
    // Set Error
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetError(byte* error);
    public static bool SetError(string error)
    {
        var bytes = StringToPtr(error);
        
        fixed (byte* ptr = bytes)
        {
            return SDL_SetError(ptr);
        }
    }
    
    // Clear Error
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_ClearError();
    public static void ClearError()
    {
        SDL_ClearError();
    }
}