namespace Hybrid
{
    public static class Time
    {
        // Delta
        public static float unscaledDeltaTime { get; internal set; } = 0f;
        public static float deltaTime { get; internal set; } = 0f;
        
        // Time
        public static float unscaledTime { get; internal set; } = 0f;
        public static float time { get; internal set; } = 0f;
        
        // Frame
        public static float frameTime { get; internal set; } = 0f;
        public static float fps { get; internal set; } = 0f;
        
        // Timescale
        public static float timeScale { get; set; } = 1f;
    }
}