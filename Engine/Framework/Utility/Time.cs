using System;

namespace Hybrid
{
    // Time
    public static partial class Time
    {
        // Delta
        public static float UnscaledDeltaTime { get; internal set; } = 0f;
        public static float DeltaTime { get; internal set; } = 0f;
        
        // Time
        public static float UnscaledTimer { get; internal set; } = 0f;
        public static float Timer { get; internal set; } = 0f;
        
        // Frame
        public static float FrameTime { get; internal set; } = 0f;
        public static float Fps { get; internal set; } = 0f;
        
        // Timescale
        public static float TimeScale { get; set; } = 1f;
    }
    
    // Frame Time
    public static partial class Time
    {
        private static readonly double Frequency = SDL.GetPerformanceFrequency();
        private static ulong Previous = SDL.GetPerformanceCounter();
        private static ulong Start = SDL.GetPerformanceCounter();
        private static float SmoothFPS;
        
        
        internal static void BeforeFrame()
        {
            // Calculate Elapsed
            Start = SDL.GetPerformanceCounter();
            var Elapsed = (Start - Previous) / Frequency;
            Previous = Start;
            
            // Calculate Time
            Time.UnscaledDeltaTime = (float)Elapsed;
            Time.UnscaledTimer += Time.UnscaledDeltaTime;
            Time.DeltaTime = Time.UnscaledDeltaTime * Time.TimeScale;
            Time.FrameTime = Time.UnscaledDeltaTime * 1000f;
            Time.Timer += Time.DeltaTime;
            
            // Calculate Fps
            if (Time.UnscaledDeltaTime > 0f)
            {
                var fps = 1f / Time.UnscaledDeltaTime;
                SmoothFPS = (SmoothFPS * 0.9f) + (fps * 0.1f);
                Time.Fps = SmoothFPS;
            }
        }
        
        internal static void AfterFrame()
        {
            // Frame Limiting
            if (Window.Fps > 0 && !Window.VSync)
            {
                // Calculate Remaining
                var Target = 1f / Window.Fps;
                var End = SDL.GetPerformanceCounter();
                var Elapsed = (End - Start) / Frequency;
                var Remaining = Target - Elapsed;

                if (Remaining > 0.0)
                {
                    // Sleep for (Remaining) nanoseconds
                    SDL.DelayPrecise((ulong)(Remaining * 1_000_000_000.0));
                }
            }
        }
    }
}