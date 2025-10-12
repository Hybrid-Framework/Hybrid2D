using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    public static string Utf8ToString(byte* bytes, bool free = false)
    {
        string s = Marshal.PtrToStringUTF8((IntPtr)bytes);
        if (free) SDL.Free((IntPtr)bytes);
        return s;
    }
    
    public static byte[] StringToUtf8(string str)
    {
        if (str == null) str = string.Empty;
        return System.Text.Encoding.UTF8.GetBytes(str + '\0');
    }
}