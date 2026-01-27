using System;

namespace Hybrid
{
    internal static class Exceptions
    {
        internal static void Throw(Exception ex, bool fatal = false)
        {
            Debug.SetColor(ConsoleColor.Red);
            
            var exception = ex.InnerException ?? ex;
            Console.WriteLine($"[{exception.GetType().Name}] {exception.Message}\n{exception.StackTrace}");
            
            #if DEBUG
            Engine.Instance.Quit();
            #elif RELEASE
            if(fatal) Engine.Instance.Quit();
            #endif
        }
    }
}