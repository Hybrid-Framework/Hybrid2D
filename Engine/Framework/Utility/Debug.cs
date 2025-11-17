using System;

namespace Hybrid
{
    // Debug API
    public static class Debug
    {
        public static void Log(string message)
        {
            SDL.LogDebug(SDL.LogCategory.Application, $"[LOG] {message}");
        }

        public static void Warn(string message)
        {
            SDL.LogWarn(SDL.LogCategory.Application, $"[WARN] {message}");
        }

        public static void Error(string message)
        {
            SDL.LogError(SDL.LogCategory.Application, $"[ERROR] {message}");
        }

        public static void Files()
        {
            // foreach (var file in Directory.GetFiles(SDL.GetBasePath()))
            // {
            //     Console.WriteLine("File: " + file);
            // }
            //
            // foreach (var directory in Directory.GetDirectories(SDL.GetBasePath()))
            // {
            //     Console.WriteLine("Directory: " + directory);
            //     
            //     foreach (var file in Directory.GetFiles(directory))
            //     {
            //         Console.WriteLine("File: " + directory + "/" + file);
            //     }
            // }
        }
    }
}