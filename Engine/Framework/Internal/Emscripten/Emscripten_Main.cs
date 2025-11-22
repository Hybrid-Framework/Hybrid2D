using System.Runtime.InteropServices;

internal static unsafe partial class Emscripten
{
    // Set Main Loop
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void emscripten_set_main_loop(IntPtr function, int fps, bool loop);
    public static void SetMainLoop(IntPtr function, int fps, bool loop)
    {
        emscripten_set_main_loop(function, fps, loop);
    }
    
    // Set Main Loop Timing
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern int emscripten_set_main_loop_timing(Mode mode, int value);
    public static int SetMainLoopTiming(Mode mode, int value)
    {
        return emscripten_set_main_loop_timing(mode, value);
    }
    
    // Get Main Loop Timing
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void emscripten_get_main_loop_timing(out Mode mode, out int value);
    public static void GetMainLoopTiming(out Mode mode, out int value)
    {
        emscripten_get_main_loop_timing(out mode, out value);
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
    
    // Cancel Main Loop
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void emscripten_cancel_main_loop();
    public static void CancelMainLoop()
    {
        emscripten_cancel_main_loop();
    }
}