using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    public static string Utf8ToString(IntPtr data, bool free = false)
    {
        if (data == IntPtr.Zero) return null;
        string result = Marshal.PtrToStringUTF8(data);

        if (free)
        {
            SDL.Free(data);
        }

        return result;
    }
    
    public static byte[] StringToUtf8(string str)
    {
        if (str == null)
        {
            str = string.Empty;
        }

        return System.Text.Encoding.UTF8.GetBytes(str + '\0');
    }
}