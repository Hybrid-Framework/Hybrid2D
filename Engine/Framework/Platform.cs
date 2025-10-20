using System;

namespace Hybrid
{
    public abstract partial class Platform : IDisposable
    {
        public static Platform Current;
        
        public static void Create(Platform platform)
        {
            Current = platform;
            Current?.Bootstrap();
        }
    }

    public abstract partial class Platform
    {
        public virtual SystemPlatform SystemPlatform { get; set; }
        public virtual GameBehaviour GameBehaviour { get; set; }
        public virtual bool Initialized { get; set; }
        public virtual bool IsRunning { get; set; }
        internal abstract void Bootstrap();

        public void Dispose()
        {
            Console.WriteLine("Dispose Platform");
        }
    }
}