using System;

namespace Engine.Platforms
{
    public class PlatformAndroid : IPlatform
    {
        public Device Device { get; set; } = Device.Android;
        
        public IFileSystem FileSystem { get; set; } = new FileSystemAndroid();
        public IDebug Debug { get; set; } = new DebugAndroid();
    }
}