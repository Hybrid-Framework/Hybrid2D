using System;

namespace Engine
{
    public interface IFileSystem
    {
        string GetPath();
        void LoadAsset();
    }
    
    public class FileSystem
    {
        public static string GetPath() => Platform.Current.FileSystem.GetPath();
        public static void LoadAsset() => Platform.Current.FileSystem.LoadAsset();
    }
}