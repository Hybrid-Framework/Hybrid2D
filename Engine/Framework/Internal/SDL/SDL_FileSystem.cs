using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Get Base Path
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetBasePath();
    public static string GetBasePath()
    {
        return Utf8ToString(SDL_GetBasePath());
    }
    
    // Get System Folder
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetUserFolder(SDL.Folder folder);
    public static string GetSystemFolder(SDL.Folder folder)
    {
        return Utf8ToString(SDL_GetUserFolder(folder));
    }
    
    // Read File
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_LoadFile(byte* path, out UIntPtr size);
    public static byte[] ReadFile(string path)
    {
        var pathBytes = StringToUtf8(path);
        
        fixed (byte* utf8 = pathBytes)
        {
            IntPtr data = SDL_LoadFile(utf8, out UIntPtr size);

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

        byte[] utf8 = StringToUtf8(path);

        fixed (byte* pPath = utf8)
        fixed (byte* pData = data)
        {
            if (!SDL_SaveFile(pPath, (IntPtr)pData, (UIntPtr)data.Length))
            {
                throw new Exception(SDL.GetError());
            }
        }
    }
}