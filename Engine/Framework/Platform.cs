using System;

namespace Hybrid
{
    public abstract partial class Platform
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
        internal virtual GameBehaviour GameBehaviour { get; set; }
        internal virtual bool Initialized { get; set; }
        internal virtual bool IsRunning { get; set; }
        
        internal abstract void Bootstrap();
        internal abstract void Quit();

        public static void Dispose()
        {
            Console.WriteLine("Disposed Platform");
            
            Window.Dispose();
        }
    }
}