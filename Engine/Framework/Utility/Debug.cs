using System;

namespace Hybrid
{
    // Debug API
    public static class Debug
    {
        public static void Log(object message, bool trace = false)
        {
            if (trace)
            {
                Console.WriteLine($"[LOG] {message}\n{Environment.StackTrace}");
                return;
            }
            
            Console.WriteLine($"[LOG] {message}");
        }
        
        public static void Warning(object message, bool trace = false)
        {
            if (trace)
            {
                Console.WriteLine($"[WARNING] {message}\n{Environment.StackTrace}");
                return;
            }
            
            Console.WriteLine($"[WARNING] {message}");
        }
        
        public static void Error(object message, bool trace = false)
        {
            if (trace)
            {
                Console.WriteLine($"[ERROR] {message}\n{Environment.StackTrace}");
                return;
            }
            
            Console.WriteLine($"[ERROR] {message}");
        }
        
        public static void Assert(bool condition, object message)
        {
            if (condition)
            {
                throw new Exception($"[ASSERT] {message}");
            }
        }
        
        public static void Exception(object message)
        {
            throw new Exception($"[EXCEPTION] {message}");
        }
    }
}