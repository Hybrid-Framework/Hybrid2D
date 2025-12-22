using System.Diagnostics;
using System;

namespace Hybrid
{
    // Time
    public static partial class Time
    {
        public static float Fps { get; internal set; }
        
        public static float UnscaledDeltaTime { get; internal set; }
        public static float SmoothDeltaTime { get; internal set; }
        public static float FixedDeltaTime { get; set; } = 0.0333f;
        public static float DeltaTime { get; internal set; }
        
        public static float RealTimeSinceStartup { get; internal set; }
        public static float UnscaledTimer { get; internal set; }
        public static float Timer { get; internal set; }

        public static float FixedFrameTime { get; internal set; }
        public static float FrameTime { get; internal set; }
        public static uint FrameCount { get; internal set; }
        
        public static float TimeScale { get; set; } = 1f;
    }
    
    // Frame
    public static partial class Time
    {
        private static readonly double FrameFrequency = SDL.GetPerformanceFrequency();
        private static readonly Stopwatch Stopwatch = Stopwatch.StartNew();
        private static long FramePrevious;
        private static long FrameStart;
        
        
        internal static void BeforeFrame()
        {
            // Calculate start counter
            FrameStart = SDL.GetPerformanceCounter();
            
            // Calculate elapsed
            var elapsed = (FrameStart - FramePrevious) / FrameFrequency;
            FramePrevious = FrameStart;
            
            // Delta Time
            Time.UnscaledDeltaTime = (float)elapsed;
            Time.DeltaTime = Time.UnscaledDeltaTime * Time.TimeScale;
            Time.SmoothDeltaTime = (Time.SmoothDeltaTime * (0.9f)) + (Time.DeltaTime * 0.1f);
            
            // Frame Timers
            Time.RealTimeSinceStartup = (float)Stopwatch.Elapsed.TotalSeconds;
            Time.UnscaledTimer += Time.UnscaledDeltaTime;
            Time.Timer += Time.DeltaTime;
            
            // Frame Time
            Time.FixedFrameTime += Time.DeltaTime;
            Time.FrameTime = Time.UnscaledDeltaTime * 1000f;

            // Frame Count
            Time.FrameCount += 1;
            
            // Frames per second
            if (Time.UnscaledDeltaTime > 0f)
            {
                Time.Fps = (Time.Fps * 0.9f) + ((1f / Time.UnscaledDeltaTime) * 0.1f);
            }

            // Spiral Prevention
            float maximum = FixedDeltaTime * 12;
            if (FixedFrameTime > maximum) FixedFrameTime = maximum;
        }
        
        internal static void AfterFrame()
        {
            // Frame Limiting
            if (Application.TargetFrameRate > 0 && !Application.VSync)
            {
                // Calculate Remaining
                var Target = 1f / Application.TargetFrameRate;
                
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