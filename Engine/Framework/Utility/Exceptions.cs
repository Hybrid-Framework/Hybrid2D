using System;

namespace Hybrid
{
    internal static class Exceptions
    {
        internal static void Execute(Exception ex)
        {
            Debug.SetColor(ConsoleColor.Red);
            
            var exception = ex.InnerException ?? ex;
            Console.WriteLine($"{exception.Message} at [{exception.TargetSite}]\n{exception.StackTrace}");
            
            #if DEBUG
            Engine.Instance.Quit();
            #endif
        }
    }
}