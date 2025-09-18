using System;

namespace Engine.Platforms
{
    public class DebugAndroid : IDebug
    {
        public void Log(string message)
        {
            Console.WriteLine($"LOG: {message} ");
        }
        
        public void Warn(string message)
        {
            Console.WriteLine($"WARNING: {message} ");
        }
        
        public void Error(string message)
        {
            throw new Exception($"ERROR: {message} ");
        }
    }
}