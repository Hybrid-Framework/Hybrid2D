using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Open URL
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_OpenURL(byte* url);
    public static void OpenURL(string url)
    {
        var bytes = StringToPtr(url);

        fixed (byte* ptr = bytes)
        {
            SDL_OpenURL(ptr);
        }
    }
}