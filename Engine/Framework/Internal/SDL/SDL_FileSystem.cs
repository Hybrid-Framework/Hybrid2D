using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Get Base Path
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetBasePath();
    public static string GetBasePath()
    {
        return PtrToString(SDL_GetBasePath());
    }
    
    // Get User Folder
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetUserFolder(SDL.Folder folder);
    public static string GetUserFolder(SDL.Folder folder)
    {
        return PtrToString(SDL_GetUserFolder(folder));
    }
    
    // Get Current Directory
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetCurrentDirectory();
    public static string GetCurrentDirectory()
    {
        return PtrToString(SDL_GetCurrentDirectory());
    }
}