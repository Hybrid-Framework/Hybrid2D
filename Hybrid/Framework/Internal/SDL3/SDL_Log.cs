using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    // Log Debug
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_LogDebug(LogCategory category, byte* message);
    internal static void LogDebug(LogCategory category, string message)
    {
        var bytes = StringToUtf8(message);

        fixed (byte* utf8 = bytes)
        {
            SDL_LogDebug(category, utf8);
        }
    }
    
    // Log Warn
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_LogWarn(LogCategory category, byte* message);
    internal static void LogWarn(LogCategory category, string message)
    {
        var bytes = StringToUtf8(message);

        fixed (byte* utf8 = bytes)
        {
            SDL_LogWarn(category, utf8);
        }
    }
    
    // Log Error
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_LogError(LogCategory category, byte* message);
    internal static void LogError(LogCategory category, string message)
    {
        throw new Exception(message);
    }
}