using System;

namespace Hybrid
{
    public interface IFileSystem
    {
        string GetBasePath();
    }
    
    public static class FileSystem
    {
        public static string GetBasePath() => Platform.Current.FileSystem.GetBasePath();

        public static string LoadAsset(string asset)
        {
            return GetBasePath() + asset;
        }
    }
}