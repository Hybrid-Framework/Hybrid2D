using System;

namespace Engine.Platforms
{
    public class DebugDesktop : IDebug
    {
        public void Log(string message)
        {
            Console.WriteLine($"{Platform.GetDevice()} LOG: {message} ");
        }
        
        public void Warn(string message)
        {
            Console.WriteLine($"{Platform.GetDevice()} WARNING: {message} ");
        }
        
        public void Error(string message)
        {
            throw new Exception($"{Platform.GetDevice()} ERROR: {message} ");
        }
    }
}