using System;

namespace Hybrid
{
    // Debug
    public static class Debug
    {
        // Log a message
        public static void Log(object message, bool trace = false)
        {
            if (trace)
            {
                Console.WriteLine($"[LOG] {message}\n{Environment.StackTrace}");
                return;
            }
            
            Console.WriteLine($"[LOG] {message}");
        }
        
        // Log a warning
        public static void Warning(object message, bool trace = false)
        {
            if (trace)
            {
                Console.WriteLine($"[WARNING] {message}\n{Environment.StackTrace}");
                return;
            }
            
            Console.WriteLine($"[WARNING] {message}");
        }
        
        // Log an error
        public static void Error(object message, bool trace = false)
        {
            if (trace)
            {
                Console.WriteLine($"[ERROR] {message}\n{Environment.StackTrace}");
                return;
            }
            
            Console.WriteLine($"[ERROR] {message}");
        }
        
        // Throw exception if condition is false
        public static void Assert(bool condition, object message)
        {
            if (!condition)
            {
                throw new Exception($"[ASSERT] {message}");
            }
        }
        
        // Throw exception
        public static void Exception(object message)
        {
            throw new Exception($"[EXCEPTION] {message}");
        }
    }
}