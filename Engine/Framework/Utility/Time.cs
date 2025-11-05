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
    
    // Time Calculating
    public static partial class Time
    {
        private static ulong _frameStart;
        private static ulong _startCounter;
        private static ulong _lastCounter;
        private static ulong _frequency;
        private static float _smoothed;


        internal static void Initialize()
        {
            // Initialize calculation
            _startCounter = SDL.GetPerformanceCounter();
            _frequency = SDL.GetPerformanceFrequency();
            _lastCounter = _startCounter;
        }
        
        internal static void BeforeFrame()
        {
            // Elapsed calculation
            _frameStart = SDL.GetPerformanceCounter();
            var elapsed = (_frameStart - _lastCounter) / (double)_frequency;
            _lastCounter = _frameStart;

            // Time calculation
            Time.UnscaledDeltaTime = (float)Math.Min(elapsed, 0.1);
            Time.DeltaTime = Time.UnscaledDeltaTime * Time.TimeScale;
            Time.FrameTime = Time.UnscaledDeltaTime * 1000f;
            Time.UnscaledTimer += Time.UnscaledDeltaTime;
            Time.Timer += Time.DeltaTime;

            // FPS calculation
            if (Time.UnscaledDeltaTime > 0f)
            {
                var instantFps = 1f / Time.UnscaledDeltaTime;
                _smoothed = (_smoothed * 0.9f) + (instantFps * 0.1f);
                Time.Fps = _smoothed;
            }
        }

        
        internal static void AfterFrame()
        {
            // Vsync & Fps limiting
            if (GraphicsDevice.Fps > 0 && !GraphicsDevice.VSync)
            {
                // Calculate frame delay
                var frameEnd = SDL.GetPerformanceCounter();
                var frameTarget = 1f / GraphicsDevice.Fps;
                var frameElapsed = (frameEnd - _frameStart) / (double)_frequency;
                var remainingTime = frameTarget - frameElapsed;

                if (remainingTime > 0.0)
                {
                    // Delay nanoseconds
                    SDL.DelayPrecise((ulong)(remainingTime * 1_000_000_000.0));
                }
            }
        }
    }
}