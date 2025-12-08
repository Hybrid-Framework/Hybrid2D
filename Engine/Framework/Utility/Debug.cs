using System;

namespace Hybrid
{
    // Debug API
    public static class Debug
    {
        public static void Log(string message)
        {
            Console.WriteLine($"[LOG] {message}");
        }

        public static void Warn(string message)
        {
            Console.WriteLine($"[WARNING] {message}");
        }

        public static void Error(string message)
        {
            throw new Exception($"[ERROR] {message}");
        }
    }
}