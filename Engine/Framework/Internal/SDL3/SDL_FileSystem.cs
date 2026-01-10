using System.Runtime.InteropServices;
using System;

internal static unsafe partial class SDL
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
    private static extern byte* SDL_GetUserFolder(SDL.Folder folder);
    public static string GetUserFolder(SDL.Folder folder)
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
    private static extern IntPtr SDL_LoadFile(byte* path, out UIntPtr size);
    public static IntPtr LoadFile(string path, out UIntPtr size)
    {
        var bytes = StringToUtf8(path);

        fixed (byte* utf8 = bytes)
        {
            return SDL_LoadFile(utf8, out size);
        }
    }
    
    // Save File
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SaveFile(byte* path, IntPtr data, UIntPtr size);
    public static bool SaveFile(string path, IntPtr data, UIntPtr size)
    {
        var bytes = StringToUtf8(path);

        fixed (byte* utf8 = bytes)
        {
            return SDL_SaveFile(utf8, data, size);
        }
    }
    
    // Create Directory
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_CreateDirectory(byte* path);
    public static bool CreateDirectory(string path)
    {
        var bytes = StringToUtf8(path);

        fixed (byte* utf8 = bytes)
        {
            return SDL_CreateDirectory(utf8);
        }
    }
    
    // Get Path Info
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetPathInfo(byte* path, out SDL.PathInfo info);
    public static bool GetPathInfo(string path, out SDL.PathInfo info)
    {
        var bytes = StringToUtf8(path);

        fixed (byte* utf8 = bytes)
        {
            return SDL_GetPathInfo(utf8, out info);
        }
    }
    
    // Glob Directory
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GlobDirectory(byte* path, byte* pattern, SDL.GlobFlags flags, out int count);
    public static IntPtr GlobDirectory(string path, string pattern, SDL.GlobFlags flags, out int count)
    {
        var bytesPath = StringToUtf8(path);
        var bytesPattern = StringToUtf8(pattern);

        fixed (byte* utf8Path = bytesPath)
        fixed (byte* utf8Pattern = bytesPattern)
        {
            return SDL_GlobDirectory(utf8Path, utf8Pattern, flags, out count);
        }
    }
}