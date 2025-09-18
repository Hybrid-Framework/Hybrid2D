using System;

namespace Engine.Platforms
{
    public class FileSystemIOS : IFileSystem
    {
        public string GetBasePath()
        {
            return "Assets/";
        }
    }
}