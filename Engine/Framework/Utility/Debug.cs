using System;

namespace Hybrid
{
    // Debug API
    public static class Debug
    {
        public enum ExceptionType { Fatal, Silent }
        private enum LogType { Log, Error, Warning, Exception }
        
        
        public static void Log(object message, bool trace = false)
        {
            Display(message, LogType.Log, trace);
        }
        
        public static void Error(object message, bool trace = false)
        {
            Display(message, LogType.Error, trace);
        }
        
        public static void Warning(object message, bool trace = false)
        {
            Display(message, LogType.Warning, trace);
        }
        
        public static void Exception(object message, ExceptionType type = ExceptionType.Fatal)
        {
            Display(message, LogType.Exception, false, type);
        }
        
        public static void Assert(bool condition, object message = null, ExceptionType type = ExceptionType.Fatal)
        {
            if (!condition)
            {
                Display(message, LogType.Exception, false, type);
            }
        }

        private static void Display(object message, LogType logType, bool trace = false, ExceptionType exceptionType = ExceptionType.Fatal)
        {
            switch (logType)
            {
                case LogType.Log:
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    
                    if (trace)
                    {
                        Console.WriteLine($"[LOG] {message}\n{Environment.StackTrace}");
                        break;
                    }
                    
                    Console.WriteLine($"[LOG] {message}");
                    break;
                }
                
                case LogType.Warning:
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    
                    if (trace)
                    {
                        Console.WriteLine($"[WARNING] {message}\n{Environment.StackTrace}");
                        break;
                    }
                    
                    Console.WriteLine($"[WARNING] {message}");
                    break;
                }
                
                case LogType.Error:
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    if (trace)
                    {
                        Console.WriteLine($"[ERROR] {message}\n{Environment.StackTrace}");
                        break;
                    }
                    
                    Console.WriteLine($"[ERROR] {message}");
                    break;
                }
                
                case LogType.Exception:
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    if (exceptionType == ExceptionType.Silent)
                    {
                        Console.WriteLine($"[EXCEPTION] {message}\n{Environment.StackTrace}");
                        break;
                    }
                    
                    throw new Exception($"{message}");
                }
            }
            
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}