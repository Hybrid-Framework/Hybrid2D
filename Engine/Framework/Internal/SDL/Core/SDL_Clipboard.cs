using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Set Clipboard Text
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetClipboardText(byte* text);
    public static void SetClipboardText(string text)
    {
        var bytes = StringToPtr(text);

        fixed (byte* ptr = bytes)
        {
            SDL_SetClipboardText(ptr);
        }
    }
    
    // Get Clipboard Text
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetClipboardText();
    public static string GetClipboardText()
    {
        return PtrToString(SDL_GetClipboardText(), true);
    }
    
    // Has Clipboard Text
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_HasClipboardText();
    public static bool HasClipboardText()
    {
        return SDL_HasClipboardText();
    }
}