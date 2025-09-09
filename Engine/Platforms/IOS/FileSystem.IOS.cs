using System;

namespace Engine.Platforms
{
    public class FileSystemIOS : IFileSystem
    {
        public string GetPath()
        {
            return "Assets";
        }
        
        public void LoadAsset()
        {
            
        }
    }
}