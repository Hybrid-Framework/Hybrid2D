using System;

namespace Engine.Platforms
{
    public class FileSystemDesktop : IFileSystem
    {
        public string GetPath()
        {
            return "Assets/";
        }
        
        public void LoadAsset()
        {
            
        }
    }
}