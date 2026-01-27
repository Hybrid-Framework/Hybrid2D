using System.Runtime.InteropServices;
using System;

internal static unsafe partial class SDL
{
    internal static string Utf8ToString(byte* ptr, bool free = false)
    {
        string text = Marshal.PtrToStringUTF8((IntPtr)ptr);
        
        if (free)
        {
            SDL.Free((IntPtr)ptr);
        }
        
        return text ?? "";
    }
    
    internal static byte[] StringToUtf8(string data)
    {
        if (data == null || data.Length <= 0)
        {
            return Array.Empty<byte>();
        }
        
        return System.Text.Encoding.UTF8.GetBytes(data + '\0');
    }
}