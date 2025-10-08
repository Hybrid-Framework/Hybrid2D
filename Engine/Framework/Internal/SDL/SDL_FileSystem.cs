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
    
    // Create Folder
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_CreateDirectory(byte* path);
    public static bool CreateFolder(string path)
    {
        var pathBytes = StringToPtr(path);

        fixed (byte* ptr = pathBytes)
        {
            return SDL_CreateDirectory(ptr);
        }
    }
    
    // Create File
    public static void CreateFile(string path)
    {
        byte[] empty = Array.Empty<byte>();
        WriteFile(path, empty);
    }
    
    // Read File
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_LoadFile(byte* path, out UIntPtr size);
    public static byte[] ReadFile(string path)
    {
        var pathBytes = StringToPtr(path);
        
        fixed (byte* ptr = pathBytes)
        {
            IntPtr data = SDL_LoadFile(ptr, out UIntPtr size);

            if (data == IntPtr.Zero)
            {
                throw new Exception(SDL.GetError());
            }

            int length = (int)size;
            byte[] bytes = new byte[length];
            Marshal.Copy(data, bytes, 0, length);
            SDL.Free(data);
            
            return bytes;
        }
    }
    
    // Write File
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SaveFile(byte* file, IntPtr data, UIntPtr size);
    public static void WriteFile(string path, byte[] data)
    {
        if (data == null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        byte[] pathBytes = StringToPtr(path);

        fixed (byte* pPath = pathBytes)
        fixed (byte* pData = data)
        {
            if (!SDL_SaveFile(pPath, (IntPtr)pData, (UIntPtr)data.Length))
            {
                throw new Exception(SDL.GetError());
            }
        }
    }
}