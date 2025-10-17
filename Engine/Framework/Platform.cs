using System;

namespace Hybrid
{
    public abstract partial class Platform
    {
        public static Platform Current;

        public static void Create(Platform platform)
        {
            Current = platform;
            Current.Init();
        }
    }
    
    public abstract partial class Platform
    {
        public virtual bool IsRunning { get; set; } = true;
        public virtual bool Initialized { get; set; } = false;

        public virtual Behaviour Behaviour { get; set; }
        
        public virtual void Init() {}
        public virtual void Run() {}
        
        public virtual void Dispose()
        {
            // Dispose Everything
        }
    }
}