using System;

namespace Engine
{
    public abstract partial class Platform
    {
        public static Platform Current;

        public static void Create(Platform platform)
        {
            Current = platform;
            Current.Run();
        }
    }
    
    public abstract partial class Platform
    {
        internal virtual bool IsRunning { get; set; } = true;
        internal virtual bool Initialized { get; set; } = false;

        internal virtual GameBehaviour GameBehaviour { get; set; }
        internal virtual IFileSystem FileSystem { get; set; }
        internal virtual IDebug Debug { get; set; }

        internal virtual void Run() {}
    }
}