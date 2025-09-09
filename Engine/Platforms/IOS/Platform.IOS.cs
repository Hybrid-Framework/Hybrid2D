using System;

namespace Engine.Platforms
{
    public class PlatformIOS : IPlatform
    {
        public Device Device { get; set; } = Device.IOS;
        
        public IFileSystem FileSystem { get; set; } = new FileSystemIOS();
        public IDebug Debug { get; set; } = new DebugIOS();
    }
}