using System;

namespace Engine.Platforms
{
    public class FileSystemAndroid : IFileSystem
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