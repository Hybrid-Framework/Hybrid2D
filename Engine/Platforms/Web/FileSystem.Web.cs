using System;

namespace Engine.Platforms
{
    public class FileSystemWeb : IFileSystem
    {
        public string GetPath()
        {
            return "/Assets";
        }
        
        public void LoadAsset()
        {
            
        }
    }
}