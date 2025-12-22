using System.Diagnostics;
using System;

namespace Hybrid
{
    // Time
    public static partial class Time
    {
        public static float TimeScale { get; set; } = 1f;
        
        public static float FramesPerSecond { get; internal set; }
        public static bool InFixedTimeStep { get; internal set; }
        public static uint FrameCount { get; internal set; }

        public static float FixedUnscaledDeltaTime { get; internal set; }
        public static float UnscaledDeltaTime { get; internal set; }
        public static float SmoothDeltaTime { get; internal set; }
        public static float FixedDeltaTime { get; set; } = 0.02f;
        public static float DeltaTime { get; internal set; }
        
        public static float RealTimeSinceStartup { get; internal set; }
        public static float FixedUnscaledTimer { get; internal set; }
        public static float UnscaledTimer { get; internal set; }
        public static float FixedTimer { get; internal set; }
        public static float Timer { get; internal set; }
        
        internal static float FixedUnscaledFrameTime { get; set; }
        internal static float UnscaledFrameTime { get; set; }
        internal static float FixedFrameTime { get; set; }
        internal static float FrameTime { get; set; }
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
            // Start
            FrameStart = SDL.GetPerformanceCounter();
            
            // Elapsed
            var elapsed = (FrameStart - FramePrevious) / FrameFrequency;
            FramePrevious = FrameStart;
            
            // Delta Time
            Time.UnscaledDeltaTime = (float)elapsed;
            Time.DeltaTime = Time.UnscaledDeltaTime * Time.TimeScale;
            Time.SmoothDeltaTime = (Time.SmoothDeltaTime * (0.9f)) + (Time.DeltaTime * 0.1f);
            Time.FixedUnscaledDeltaTime = Time.TimeScale > 0 ? Time.FixedDeltaTime / Time.TimeScale : Time.FixedDeltaTime;
            
            // Timers
            Time.RealTimeSinceStartup = (float)Stopwatch.Elapsed.TotalSeconds;
            Time.UnscaledTimer += Time.UnscaledDeltaTime;
            Time.Timer += Time.DeltaTime;
            
            // Frame Time
            Time.FixedFrameTime += Time.DeltaTime;
            Time.FrameTime = Time.DeltaTime * 1000f;
            Time.FixedUnscaledFrameTime += Time.UnscaledDeltaTime;
            Time.UnscaledFrameTime = Time.UnscaledDeltaTime * 1000f;
            
            // Frame
            Time.FramesPerSecond = (Time.FramesPerSecond * 0.9f) + ((1f / Time.UnscaledDeltaTime) * 0.1f);
            Time.FrameCount += 1;
            
            // Fixed Spiral Prevention
            if (FixedFrameTime > (FixedDeltaTime * 12))
            {
                FixedFrameTime = FixedDeltaTime * 12;
            }
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