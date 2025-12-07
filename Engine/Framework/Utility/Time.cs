using System;

namespace Hybrid
{
    // Time
    public static partial class Time
    {
        public static float UnscaledDeltaTime { get; internal set; }
        public static float FixedDeltaTime { get; set; } = 0.0333f;
        public static float DeltaTime { get; internal set; }
        
        public static float UnscaledTimer { get; internal set; }
        public static float Timer { get; internal set; }

        public static float FixedFrameTime { get; internal set; }
        public static float FrameTime { get; internal set; }
        public static float Fps { get; internal set; }
        
        public static float TimeScale { get; set; } = 1f;
    }
    
    // Frame
    public static partial class Time
    {
        private static readonly double FrameFrequency = SDL.GetPerformanceFrequency();
        private static ulong FramePrevious = SDL.GetPerformanceCounter();
        private static ulong FrameStart = SDL.GetPerformanceCounter();
        
        
        internal static void BeforeFrame()
        {
            FrameStart = SDL.GetPerformanceCounter();
            
            // Calculate Elapsed
            var Elapsed = (FrameStart - FramePrevious) / FrameFrequency;
            FramePrevious = FrameStart;
            
            // Calculate Time
            Time.UnscaledDeltaTime = (float)Elapsed;
            Time.DeltaTime = Time.UnscaledDeltaTime * Time.TimeScale;
            
            Time.UnscaledTimer += Time.UnscaledDeltaTime;
            Time.Timer += Time.DeltaTime;
            
            Time.FixedFrameTime += Time.DeltaTime;
            Time.FrameTime = Time.UnscaledDeltaTime * 1000f;
            
            Time.Fps = 1f / Time.UnscaledDeltaTime;

            // Calculate Spiral Prevention
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