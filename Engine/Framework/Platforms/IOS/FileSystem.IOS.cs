using System;

namespace Hybrid.Platforms
{
    public class FileSystemIOS : IFileSystem
    {
        public string GetBasePath()
        {
            return "Assets/";
        }
    }
}