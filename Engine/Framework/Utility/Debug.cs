using System;

namespace Hybrid
{
    public class Debug
    {
        public static void Log(string message)
        {
            SDL.LogDebug(SDL.LogCategory.Application, message);
        }

        public static void Warn(string message)
        {
            SDL.LogWarn(SDL.LogCategory.Application, message);
        }

        public static void Error(string message)
        {
            SDL.LogError(SDL.LogCategory.Application, message);
        }
    }
}