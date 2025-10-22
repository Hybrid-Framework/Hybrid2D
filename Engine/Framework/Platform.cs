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
        internal static SystemPlatform SystemPlatform { get; set; }
        internal static SystemDevice SystemDevice { get; set; }
        internal static bool Initialized { get; set; }
        internal static bool IsRunning { get; set; }
        internal abstract void Bootstrap();
        
        
        internal void Initialize()
        {
            GameBehaviour?.Init();
            Initialized = true;
            IsRunning = true;
        }
        
        internal void MainLoop()
        {
            if (Window.GetWindow() == null)
            {
                throw new Exception("Please create a window inside Init(); using Window.Create(...);");
            }
            
            while (SDL.PollEvent(out SDL.Event e))
            {
                var type = (SDL.EventType)e.type;

                if (type == SDL.EventType.Quit)
                {
                    Current?.Quit();
                    return;
                }
            }
            
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