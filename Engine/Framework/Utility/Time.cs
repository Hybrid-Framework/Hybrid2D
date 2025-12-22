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

        public static float RealTimeSinceSceneStartup => (float)Time.SceneWatch.Elapsed.TotalSeconds;
        public static float RealTimeSinceStartup => (float)Time.RealWatch.Elapsed.TotalSeconds;
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
        internal static double FrameFrequency { get; set; } = SDL.GetPerformanceFrequency();
        internal static Stopwatch SceneWatch { get; set; } = Stopwatch.StartNew();
        internal static Stopwatch RealWatch { get; set; } = Stopwatch.StartNew();
        internal static long FramePrevious { get; set; }
        internal static long FrameStart  { get; set; }
        
        
        internal static void BeforeFrame()
        {
            // Start
            Time.FrameStart = SDL.GetPerformanceCounter();
            
            // Elapsed
            var elapsed = (Time.FrameStart - Time.FramePrevious) / Time.FrameFrequency;
            Time.FramePrevious = Time.FrameStart;
            
            // Delta Time
            Time.UnscaledDeltaTime = (float)elapsed;
            Time.DeltaTime = Time.UnscaledDeltaTime * Time.TimeScale;
            Time.SmoothDeltaTime = (Time.SmoothDeltaTime * (0.9f)) + (Time.DeltaTime * 0.1f);
            Time.FixedUnscaledDeltaTime = Time.TimeScale > 0 ? Time.FixedDeltaTime / Time.TimeScale : Time.FixedDeltaTime;
            
            // Timers
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
            if (Time.FixedFrameTime > (Time.FixedDeltaTime * 12))
            {
                Time.FixedFrameTime = Time.FixedDeltaTime * 12;
            }
        }
        
        internal static void AfterFrame()
        {
            // Frame Limiting
            if (Application.TargetFrameRate > 0 && !Application.VSync)
            {
                // Calculate Remaining
                var target = 1f / Application.TargetFrameRate;
                
                var frameEnd = SDL.GetPerformanceCounter();
                var frameElapsed = (frameEnd - Time.FrameStart) / Time.FrameFrequency;
                var frameRemaining = target - frameElapsed;

                if (frameRemaining > 0.0)
                {
                    // Sleep for (Remaining) nanoseconds
                    SDL.DelayPrecise((ulong)(frameRemaining * 1_000_000_000.0));
                }
            }
        }
    }
}