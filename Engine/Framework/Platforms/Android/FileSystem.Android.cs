using System;

namespace Engine.Platforms
{
    public class FileSystemAndroid : IFileSystem
    {
        public string GetBasePath()
        {
            return "Assets/";
        }
    }
}