using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    public static string PtrToString(IntPtr data, bool free = false)
    {
        if (data == IntPtr.Zero) return null;
        string result = Marshal.PtrToStringUTF8(data);

        if (free)
        {
            SDL_free(data);
        }

        return result;
    }
    
    public static byte[] StringToPtr(string str)
    {
        if (str == null) str = string.Empty;

        return System.Text.Encoding.UTF8.GetBytes(str + '\0');
    }
}