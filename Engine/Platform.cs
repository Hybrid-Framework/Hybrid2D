using static Engine.Internal.SDL2.SDL;
using System;

namespace Engine
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
        public abstract Game Game { get; set; }
        public abstract IDevice Device { get; set; }
        
        public abstract IFileSystem FileSystem { get; set; }
        public abstract IDebug Debug { get; set; }

        public abstract void Init();
        public abstract void Run();
    }
}