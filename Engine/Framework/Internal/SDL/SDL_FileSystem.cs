using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Get Base Path
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern byte* SDL_GetBasePath();
    public static string GetBasePath()
    {
        return Utf8ToString(SDL_GetBasePath());
    }
    
    // Get User Path
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern byte* SDL_GetUserFolder(SDL.SystemFolder folder);
    public static string GetUserFolder(SDL.SystemFolder folder)
    {
        return Utf8ToString(SDL_GetUserFolder(folder));
    }
    
    // Get Current Directory
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern byte* SDL_GetCurrentDirectory();
    public static string GetCurrentDirectory()
    {
        return Utf8ToString(SDL_GetCurrentDirectory());
    }
    
    // Remove Path
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RemovePath(byte* path);
    public static bool RemovePath(string path)
    {
        var bytes = StringToUtf8(path);

        fixed (byte* utf8 = bytes)
        {
            return SDL_RemovePath(utf8);
        }
    }
    
    // Rename Path
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenamePath(byte* oldPath, byte* newPath);
    public static bool RenamePath(string oldPath, string newPath)
    {
        var bytesOld = StringToUtf8(oldPath);
        var bytesNew = StringToUtf8(newPath);

        fixed (byte* utf8Old = bytesOld)
        fixed (byte* utf8New = bytesNew)
        {
            return SDL_RenamePath(utf8Old, utf8New);
        }
    }
    
    // Copy File
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_CopyFile(byte* oldPath, byte* newPath);
    public static bool CopyFile(string oldPath, string newPath)
    {
        var bytesOld = StringToUtf8(oldPath);
        var bytesNew = StringToUtf8(newPath);

        fixed (byte* utf8Old = bytesOld)
        fixed (byte* utf8New = bytesNew)
        {
            return SDL_CopyFile(utf8Old, utf8New);
        }
    }
    
    // Load File
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern byte* SDL_LoadFile(byte* file, out UIntPtr size);
    public static byte* LoadFile(string file, out UIntPtr size)
    {
        var bytes = StringToUtf8(file);

        fixed (byte* utf8 = bytes)
        {
            return SDL_LoadFile(utf8, out size);
        }
    }
    
    // Save File
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SaveFile(byte* file, byte* data, UIntPtr size);
    public static bool SaveFile(string file, byte* data, UIntPtr size)
    {
        var bytes = StringToUtf8(file);

        fixed (byte* utf8 = bytes)
        {
            return SDL_SaveFile(utf8, data, size);
        }
    }
}