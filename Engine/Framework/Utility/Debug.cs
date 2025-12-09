using System;

namespace Hybrid
{
    // Debug API
    public static class Debug
    {
        public static void Log(object message)
        {
            Console.WriteLine($"[LOG] {message}");
        }

        public static void Warn(object message)
        {
            Console.WriteLine($"[WARNING] {message}");
        }

        public static void Error(object message)
        {
            throw new Exception($"[ERROR] {message}");
        }
    }
}