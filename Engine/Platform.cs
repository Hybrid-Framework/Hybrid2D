using System;

namespace Engine
{
    public interface IPlatform
    {
        public Device Device { get; set; }
        
        public IFileSystem FileSystem { get; set; }
        public IDebug Debug { get; set; }
    }
    
    public static class Platform
    {
        public static IPlatform Current;

        public static void Create(IPlatform platform)
        {
            Current = platform;
        }

        public static Device GetDevice()
        {
            return Current.Device;
        }
    }

    public enum Device
    {
        Unknown,
        Desktop,
        Android,
        IOS,
        Web
    }
}