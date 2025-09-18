using System;

namespace Hybrid.Platforms
{
    public class FileSystemDesktop : IFileSystem
    {
        public string GetBasePath()
        {
            return "Assets/";
        }
    }
}