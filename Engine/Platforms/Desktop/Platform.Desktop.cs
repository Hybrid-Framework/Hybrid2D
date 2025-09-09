using System;

namespace Engine.Platforms
{
    public class PlatformDesktop : IPlatform
    {
        public Device Device { get; set; } = Device.Desktop;
        
        public IFileSystem FileSystem { get; set; } = new FileSystemDesktop();
        public IDebug Debug { get; set; } = new DebugDesktop();
    }
}