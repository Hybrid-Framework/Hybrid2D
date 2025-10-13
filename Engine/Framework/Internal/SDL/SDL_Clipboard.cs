using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Set Clipboard Text
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetClipboardText(byte* text);
    public static bool SetClipboardText(string text)
    {
        var bytes = StringToUtf8(text);

        fixed (byte* utf8 = bytes)
        {
            return SDL_SetClipboardText(utf8);
        }
    }
    
    // Get Clipboard Text
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern byte* SDL_GetClipboardText();
    public static string GetClipboardText()
    {
        return Utf8ToString(SDL_GetClipboardText());
    }
    
    // Has Clipboard Text
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_HasClipboardText();
    public static bool HasClipboardText()
    {
        return SDL_HasClipboardText();
    }
}