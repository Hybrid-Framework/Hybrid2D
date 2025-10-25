namespace Hybrid
{
    public static class FileSystem
    {
        public static string basePath
        {
            get => SDL.GetBasePath();
        }
        
        public static string assetPath
        {
            get => Path.Combine(basePath, "Assets/");
        }
    }
}