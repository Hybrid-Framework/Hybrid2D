using System;

namespace Hybrid
{
    // Internal
    public sealed partial class Time : Module
    {
        internal Time() { }
        
        private static double FrameFrequency { get; set; } = SDL.GetPerformanceFrequency();
        private static long FramePrevious { get; set; } = SDL.GetPerformanceCounter();
        private static long FrameStart { get; set; } = SDL.GetPerformanceCounter();
        private static float FrameTime { get; set; }
        private static int FrameCount { get; set; }
        
        private static float TargetFramesPerSecond { get; set; }
        private static float FramesPerSecond { get; set; }
        private static float DeltaTime { get; set; }
        private static float Timer { get; set; }


        // Initialize
        internal override void OnInitialize()
        {
            FrameFrequency = SDL.GetPerformanceFrequency();
            FramePrevious = SDL.GetPerformanceCounter();
            FrameStart = SDL.GetPerformanceCounter();
        }

        // Start Of Frame
        internal override void OnStartOfFrame()
        {
            FrameStart = SDL.GetPerformanceCounter();

            DeltaTime = (float)((FrameStart - FramePrevious) / FrameFrequency);
            FramesPerSecond = Math.Max((FramesPerSecond * 0.9f) + ((1f / DeltaTime) * 0.1f), 0f);
            FrameTime = DeltaTime * 1000f;
            Timer += DeltaTime;
            FrameCount += 1;

            FramePrevious = FrameStart;
        }

        // End Of Frame
        internal override void OnEndOfFrame()
        {
            if (TargetFramesPerSecond > 0)
            {
                var target = 1f / TargetFramesPerSecond;
                var frameEnd = SDL.GetPerformanceCounter();
                var frameElapsed = (frameEnd - FrameStart) / FrameFrequency;
                var frameRemaining = target - frameElapsed;

                if (frameRemaining > 0.0)
                {
                    SDL.DelayPrecise((ulong)(frameRemaining * 1_000_000_000.0));
                }
            }
        }
    }
    
    // Time API
    public sealed partial class Time
    {
        // Get frame count
        public static int GetFrameCount()
        {
            return FrameCount;
        }
        
        // Get frame time in ms
        public static float GetFrameTime()
        {
            return FrameTime;
        }
        
        // Get delta time
        public static float GetDeltaTime()
        {
            return DeltaTime;
        }
        
        // Get time since startup
        public static float GetTime()
        {
            return Timer;
        }
        
        // Set target frame rate
        public static void SetFps(int fps)
        {
            TargetFramesPerSecond = fps;
        }

        // Get target frame rate
        public static float GetFps()
        {
            return FramesPerSecond;
        }
    }
}