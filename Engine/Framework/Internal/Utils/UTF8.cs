using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    public static string Utf8ToString(byte* ptr, bool free = false)
    {
        string text = Marshal.PtrToStringUTF8((IntPtr)ptr);
        if (free) SDL.Free((IntPtr)ptr);
        return text;
    }
    
    public static byte[] StringToUtf8(string text)
    {
        if (text == null) text = string.Empty;
        return System.Text.Encoding.UTF8.GetBytes(text + '\0');
    }
}