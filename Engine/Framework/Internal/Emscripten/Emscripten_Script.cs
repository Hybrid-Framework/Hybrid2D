using System.Runtime.InteropServices;

internal static unsafe partial class Emscripten
{
    // Run Script
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void emscripten_run_script(byte* script);
    public static void RunScript(string script)
    {
        var bytes = SDL.StringToUtf8(script);

        fixed (byte* utf8 = bytes)
        {
            emscripten_run_script(utf8);
        }
    }
    
    // Run Script Int
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern int emscripten_run_script_int(byte* script);
    public static int RunScriptInt(string script)
    {
        var bytes = SDL.StringToUtf8(script);

        fixed (byte* utf8 = bytes)
        {
            return emscripten_run_script_int(utf8);
        }
    }
    
    // Run Script String
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern byte* emscripten_run_script_string(byte* script);
    public static string RunScriptString(string script)
    {
        var bytes = SDL.StringToUtf8(script);

        fixed (byte* utf8 = bytes)
        {
            return SDL.Utf8ToString(emscripten_run_script_string(utf8));
        }
    }
}