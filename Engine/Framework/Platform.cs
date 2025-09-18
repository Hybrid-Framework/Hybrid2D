using System;
using Hybrid.SDL2;

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
        internal virtual bool IsRunning { get; set; } = true;
        internal virtual bool Initialized { get; set; } = false;

        internal virtual GameBehaviour GameBehaviour { get; set; }
        internal virtual IFileSystem FileSystem { get; set; }
        internal virtual IDebug Debug { get; set; }
        
        public virtual void Init() {}
        public virtual void Run() {}
        
        internal virtual void Dispose()
        {
            // Dispose
            Window.CloseWindow();
        }
    }
}