using System;

namespace Engine.Platforms
{
    public class FileSystemDesktop : IFileSystem
    {
        public string GetBasePath()
        {
            return "Assets/";
        }
    }
}