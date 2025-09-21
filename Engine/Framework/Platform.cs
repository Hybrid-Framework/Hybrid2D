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
            SDL_init.Init();
            Current.Init();
        }
    }
    
    public abstract partial class Platform
    {
        public virtual bool IsRunning { get; set; } = true;
        public virtual bool Initialized { get; set; } = false;

        internal virtual Behaviour Behaviour { get; set; }
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