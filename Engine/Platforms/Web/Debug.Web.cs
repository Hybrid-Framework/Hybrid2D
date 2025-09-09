using System;

namespace Engine.Platforms
{
    public class DebugWeb : IDebug
    {
        public void Log(string message)
        {
            Console.WriteLine($"{Platform.Current.Device} LOG: {message} ");
        }
        
        public void Warn(string message)
        {
            Console.WriteLine($"{Platform.Current.Device} WARNING: {message} ");
        }
        
        public void Error(string message)
        {
            throw new Exception($"{Platform.Current.Device} ERROR: {message} ");
        }
    }
}