using System;

namespace Hybrid
{
    internal static class Exceptions
    {
        internal static void Throw(Exception ex, App app)
        {
            var exception = ex.InnerException ?? ex;
            
            Console.WriteLine($"[{exception.GetType().Name}] {exception.Message}\n{exception.StackTrace}");
            {
                app?.Quit();
            }
        }
    }
}