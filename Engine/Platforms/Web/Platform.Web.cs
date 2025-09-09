using System;

namespace Engine.Platforms
{
    public class PlatformWeb : IPlatform
    {
        public Device Device { get; set; } = Device.Web;
        
        public IFileSystem FileSystem { get; set; } = new FileSystemWeb();
        public IDebug Debug { get; set; } = new DebugWeb();
    }
}