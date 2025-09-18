using System;

namespace Hybrid.Platforms
{
    public class FileSystemAndroid : IFileSystem
    {
        public string GetBasePath()
        {
            return "Assets/";
        }
    }
}