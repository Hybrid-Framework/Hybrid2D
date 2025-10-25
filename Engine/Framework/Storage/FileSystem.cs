namespace Hybrid
{
    public static class FileSystem
    {
        public static string BasePath
        {
            get => SDL.GetBasePath();
        }
    }
}