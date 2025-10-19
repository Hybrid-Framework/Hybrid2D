using System.Runtime.InteropServices;

internal static unsafe partial class Emscripten
{
    // Library
    public const string library = "__Internal_emscripten";
    
    // Main Function
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void MainFunction();
    
    // Timing Mode
    public enum TimingMode
    {
        RequestAnimationFrame = 1,
        Immediate = 2,
        Timeout = 0,
    }
    
    // Set Main Loop
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void emscripten_set_main_loop(IntPtr function, int fps, bool loop);
    public static void SetMainLoop(IntPtr function, int fps, bool loop)
    {
        emscripten_set_main_loop(function, fps, loop);
    }
    
    // Set Main Loop Timing
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern int emscripten_set_main_loop_timing(TimingMode mode, int value);
    public static int SetMainLoopTiming(TimingMode mode, int value)
    {
        return emscripten_set_main_loop_timing(mode, value);
    }
    
    // Get Main Loop Timing
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void emscripten_get_main_loop_timing(out TimingMode mode, out int value);
    public static void GetMainLoopTiming(out TimingMode mode, out int value)
    {
        emscripten_get_main_loop_timing(out mode, out value);
    }
    
    // Cancel Main Loop
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void emscripten_cancel_main_loop();
    public static void CancelMainLoop()
    {
        emscripten_cancel_main_loop();
    }
    
    // Pause Main Loop
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void emscripten_pause_main_loop();
    public static void PauseMainLoop()
    {
        emscripten_pause_main_loop();
    }
    
    // Resume Main Loop
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void emscripten_resume_main_loop();
    public static void ResumeMainLoop()
    {
        emscripten_resume_main_loop();
    }
    
    // Get Window Title
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern byte* emscripten_get_window_title();
    public static string GetWindowTitle()
    {
        return SDL.Utf8ToString(emscripten_get_window_title());
    }
    
    // Set Window Title
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void emscripten_set_window_title(byte* title);
    public static void SetWindowTitle(string title)
    {
        var bytes = SDL.StringToUtf8(title);

        fixed (byte* utf8 = bytes)
        {
            emscripten_set_window_title(utf8);
        }
    }
}