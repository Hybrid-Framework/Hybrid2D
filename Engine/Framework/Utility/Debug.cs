using System;

namespace Hybrid
{
    // Debug API
    public static class Debug
    {
        public enum ExceptionType { Normal, Fatal, Silent }
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
        
        public static void Exception(object message, ExceptionType type)
        {
            Display(message, LogType.Exception, false, type);
        }
        
        public static void Assert(bool condition, object message, ExceptionType type)
        {
            if (!condition)
            {
                Display(message, LogType.Exception, false, type);
            }
        }

        private static void Display(object message, LogType log, bool trace = false, ExceptionType exception = ExceptionType.Fatal)
        {
            switch (log)
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

                    if (exception == ExceptionType.Normal)
                    {
                        Console.WriteLine($"[EXCEPTION] {message}\n{Environment.StackTrace}");
                        break;
                    }

                    if (exception == ExceptionType.Fatal)
                    {
                        throw new Exception($"{message}");
                    }

                    if (exception == ExceptionType.Silent)
                    {
                        Environment.Exit(1);
                    }

                    break;
                }
            }
            
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}