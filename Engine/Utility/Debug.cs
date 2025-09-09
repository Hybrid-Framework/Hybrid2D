using System;

namespace Engine
{
    public interface IDebug
    {
        void Log(string message);
        void Warn(string message);
        void Error(string message);
    }
    
    public static class Debug
    {
        public static void Log(string message) => Platform.Current.Debug.Log(message);
        public static void Warn(string message) => Platform.Current.Debug.Warn(message);
        public static void Error(string message) => Platform.Current.Debug.Error(message);
    }
}