using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    public static string Utf8ToString(byte* ptr, bool free = false)
    {
        string text = Marshal.PtrToStringUTF8((IntPtr)ptr);
        if (free) SDL.Free((IntPtr)ptr);
        return text;
    }
    
    public static byte[] StringToUtf8(string data)
    {
        return System.Text.Encoding.UTF8.GetBytes(data + '\0');
    }
}