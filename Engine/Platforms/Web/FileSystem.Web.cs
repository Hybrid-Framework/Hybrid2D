using System;

namespace Engine.Platforms
{
    public class FileSystemWeb : IFileSystem
    {
        public string GetBasePath()
        {
            return "/Assets/";
        }
    }
}