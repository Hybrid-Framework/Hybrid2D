using System;

namespace Hybrid
{
    public abstract partial class Platform : IDisposable
    {
        internal static Platform Current;
        
        public static void Create(Platform platform)
        {
            Current = platform;
            Current?.Bootstrap();
        }
    }

    public abstract partial class Platform
    {
        internal virtual SystemPlatform SystemPlatform { get; set; }
        internal virtual SystemDevice SystemDevice { get; set; }

        internal virtual GameBehaviour GameBehaviour { get; set; }

        internal virtual bool Initialized { get; set; }
        internal virtual bool IsRunning { get; set; }

        internal abstract void Bootstrap();
        internal abstract void Quit();
    }
    
    public abstract partial class Platform
    {
        bool disposed;
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool dispose)
        {
            if (disposed) return;
            disposed = true;

            if (dispose)
            {
                Console.WriteLine("Disposing...");
                
                Window.Dispose();
            }
        }
    }
}