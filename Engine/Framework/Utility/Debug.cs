using System;

namespace Hybrid
{
    // Debug API
    public static class Debug
    {
        enum LogType
        {
            Log,
            Error,
            Warning,
            Exception
        }
        
        public static void Log(object message)
        {
            Show(message, LogType.Log);
        }

        public static void LogError(object message)
        {
            Show(message, LogType.Error);
        }
        
        public static void LogWarning(object message)
        {
            Show(message, LogType.Warning);
        }
        
        public static void LogException(object message)
        {
            Show(message, LogType.Exception);
        }

        private static void Show(object message, LogType type)
        {
            switch (type)
            {
                case LogType.Log:
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"[LOG] {message}");
                    break;
                }
                case LogType.Error:
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[ERROR] {message}");
                    break;
                }
                case LogType.Warning:
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"[WARNING] {message}");
                    break;
                }
                case LogType.Exception:
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new Exception($"{message}");
                }
            }
            
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}