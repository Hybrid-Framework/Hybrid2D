using System.Diagnostics;
using System;

namespace Hybrid
{
    // Time
    public static partial class Time
    {
        public static float TimeScale { get; set; } = 1f;
        
        public static float FramesPerSecond { get; internal set; }
        public static uint FrameCount { get; internal set; }
        
        public static float UnscaledDeltaTime { get; internal set; }
        public static float SmoothDeltaTime { get; internal set; }
        public static float DeltaTime { get; internal set; }

        public static float UnscaledTimer { get; internal set; }
        public static float Timer { get; internal set; }
        
        public static float UnscaledFrameTime { get; internal set; }
        public static float FrameTime { get; internal set; }
    }
    
    // Internal
    public static partial class Time
    {
        private static readonly double FrameFrequency = SDL.GetPerformanceFrequency();
        private static long FramePrevious = SDL.GetPerformanceCounter();
        private static long FrameStart = SDL.GetPerformanceCounter();
        
        
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
            
            // Timers
            Time.UnscaledTimer += Time.UnscaledDeltaTime;
            Time.Timer += Time.DeltaTime;
            
            // Frame
            Time.FrameCount += 1;
            Time.FrameTime = Time.DeltaTime * 1000f;
            Time.UnscaledFrameTime = Time.UnscaledDeltaTime * 1000f;
            Time.FramesPerSecond = Maths.Clamp((Time.FramesPerSecond * 0.9f) + ((1f / Time.UnscaledDeltaTime) * 0.1f), 0, 10000);
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