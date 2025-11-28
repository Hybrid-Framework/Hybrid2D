using System;

namespace Hybrid
{
    // Time
    public static partial class Time
    {
        public static float UnscaledDeltaTime { get; internal set; } = 0f;
        public static float DeltaTime { get; internal set; } = 0f;
        
        public static float UnscaledTimer { get; internal set; } = 0f;
        public static float Timer { get; internal set; } = 0f;
        
        public static float FrameTime { get; internal set; } = 0f;
        public static float Fps { get; internal set; } = 0f;
        
        public static float TimeScale { get; set; } = 1f;
    }
    
    // Frame
    public static partial class Time
    {
        private static readonly double FrameFrequency = SDL.GetPerformanceFrequency();
        private static ulong FramePrevious = SDL.GetPerformanceCounter();
        private static ulong FrameStart = SDL.GetPerformanceCounter();
        private static float Smoothed;
        
        
        internal static void BeforeFrame()
        {
            FrameStart = SDL.GetPerformanceCounter();
            
            // Calculate Elapsed
            var Elapsed = (FrameStart - FramePrevious) / FrameFrequency;
            FramePrevious = FrameStart;
            
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
                Smoothed = (Smoothed * 0.9f) + (fps * 0.1f);
                Time.Fps = Smoothed;
            }
        }
        
        internal static void AfterFrame()
        {
            // Frame Limiting
            if (Window.Fps > 0 && !Window.VSync)
            {
                // Calculate Remaining
                var Target = 1f / Window.Fps;
                
                var FrameEnd = SDL.GetPerformanceCounter();
                var FrameElapsed = (FrameEnd - FrameStart) / FrameFrequency;
                var FrameRemaining = Target - FrameElapsed;

                if (FrameRemaining > 0.0)
                {
                    // Sleep for (Remaining) nanoseconds
                    SDL.DelayPrecise((ulong)(FrameRemaining * 1_000_000_000.0));
                }
            }
        }
    }
}