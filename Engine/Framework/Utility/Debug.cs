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

        public static void LogWarning(object message)
        {
            Console.WriteLine($"[WARNING] {message}");
        }

        public static void LogError(object message)
        {
            Console.WriteLine($"[ERROR] {message}");
        }
        
        public static void LogMessage(string tag, object message)
        {
            Console.WriteLine($"[{tag}] {message}");
        }
        
        public static void LogException(object message)
        {
            throw new Exception($"{message}");
        }
    }
}