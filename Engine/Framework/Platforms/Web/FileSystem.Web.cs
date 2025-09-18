using System;

namespace Hybrid.Platforms
{
    public class FileSystemWeb : IFileSystem
    {
        public string GetBasePath()
        {
            return "/Assets/";
        }
    }
}