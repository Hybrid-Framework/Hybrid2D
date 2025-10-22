using System;

namespace Hybrid
{
    #region Platform Creation
    public abstract partial class Platform : IDisposable
    {
        internal static GameBehaviour GameBehaviour { get; set; }
        internal static Platform Current { get; set; }

        public static void Create(Platform platform)
        {
            Current = platform;
            Current?.Bootstrap();
        }
    }
    #endregion

    
    #region Platform Behaviour
    public abstract unsafe partial class Platform
    {
        internal virtual SystemPlatform SystemPlatform { get; set; }
        internal virtual SystemDevice SystemDevice { get; set; }
        internal static bool Initialized { get; set; }
        internal static bool IsRunning { get; set; }
        internal abstract void Bootstrap();
        
        private ulong _startCounter;
        private ulong _lastCounter;
        private ulong _frequency;
        private float _smoothed;
        
        
        internal void Initialize()
        {
            if (!Initialized)
            {
                // Frame Timing
                _startCounter = SDL.GetPerformanceCounter();
                _frequency = SDL.GetPerformanceFrequency();
                _lastCounter = _startCounter;
                
                Time.deltaTime = 0f;
                Time.frameTime = 0f;
                Time.time = 0f;
                Time.fps = 0f;
                
                // Initialize
                GameBehaviour?.Initialize();
                Initialized = true;
                IsRunning = true;
            }
        }
        
        internal void MainLoop()
        {
            // Window
            if (Window.GetWindow() == null || Window.GetRenderer() == null)
            {
                throw new Exception("Please create a window using Window.Create(...);");
            }
            
            // Frame Timing
            ulong currentCounter = SDL.GetPerformanceCounter();
            double elapsed = (currentCounter - _lastCounter) / (double)_frequency;
            _lastCounter = currentCounter;

            Time.unscaledDeltaTime = (float)Math.Min(elapsed, 0.1);
            Time.deltaTime = Time.unscaledDeltaTime * Time.timeScale;

            Time.unscaledTime += Time.unscaledDeltaTime;
            Time.time += Time.deltaTime;

            Time.frameTime = Time.unscaledDeltaTime * 1000f;
            Time.fps = _smoothed = (_smoothed * 0.9f) + ((1f / Time.unscaledDeltaTime) * 0.1f);
            
            // Events
            while (SDL.PollEvent(out SDL.Event e))
            {
                var type = (SDL.EventType)e.type;

                if (type == SDL.EventType.Quit)
                {
                    Current?.Quit();
                    return;
                }
            }
            
            // Main Loop
            GameBehaviour?.Update();
            GameBehaviour?.Draw();
        }

        internal void Quit()
        {
            IsRunning = false;
            Dispose(true);
        }
    }
    #endregion
    

    #region Platform Dispose
    public abstract partial class Platform
    {
        internal static bool disposed { get; set; }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public static void Dispose(bool dispose)
        {
            if (disposed) return;
            disposed = true;

            if (dispose)
            {
                // Dispose
                Window.Dispose();
            }
        }
    }
    #endregion
}