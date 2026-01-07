using System;

namespace Hybrid
{
    // Debug API
    public static class Debug
    {
        public static void Color(ConsoleColor color)
        {
            try
            {
                Console.ForegroundColor = color;
            }
            catch (PlatformNotSupportedException)
            {
                // Unsupported platform
            }
        }
        
        public static void Log(object message, bool trace = false)
        {
            Color(ConsoleColor.Black);
            
            if (trace)
            {
                Console.WriteLine($"[LOG] {message}\n{Environment.StackTrace}");
                return;
            }
            
            Console.WriteLine($"[LOG] {message}");
        }
        
        public static void Warning(object message, bool trace = false)
        {
            Color(ConsoleColor.Yellow);
            
            if (trace)
            {
                Console.WriteLine($"[WARNING] {message}\n{Environment.StackTrace}");
                return;
            }
            
            Console.WriteLine($"[WARNING] {message}");
        }
        
        public static void Error(object message, bool trace = false)
        {
            Color(ConsoleColor.Red);
            
            if (trace)
            {
                Console.WriteLine($"[ERROR] {message}\n{Environment.StackTrace}");
                return;
            }
            
            Console.WriteLine($"[ERROR] {message}");
        }
        
        public static void Assert(bool condition, object message)
        {
            Color(ConsoleColor.Red);
            
            if (condition)
            {
                throw new Exception($"{message}");
            }
        }
        
        public static void Exception(object message)
        {
            Color(ConsoleColor.Red);
            
            throw new Exception($"{message}");
        }
    }
}