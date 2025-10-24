using System;

namespace Hybrid
{
    public static class Time
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
}