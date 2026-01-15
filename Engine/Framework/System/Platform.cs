using System;

namespace Hybrid
{
    // Device API
    public static class Platform
    {
        public static string GetPlatform()
        {
            return SDL.GetPlatform().ToUpper() switch
            {
                "ANDROID" => "ANDROID",
                "WINDOWS" => "WINDOWS",
                "EMSCRIPTEN" => "WEB",
                "MACOS" => "MACOS",
                "LINUX" => "LINUX",
                "IOS" => "IOS",
                
                _ => "UNKNOWN"
            };
        }

        public static string GetOSVersion()
        {
            return Environment.OSVersion.ToString();
        }

        public static int GetProcessorCount()
        {
            return Environment.ProcessorCount;
        }

        public static bool GetProcessor64Bit()
        {
            return Environment.Is64BitProcess;
        }
        
        public static string GetDate()
        {
            return DateTime.Now.ToString("dd-MM-yyyy");
        }

        public static string GetTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }
        
        public static int GetMonth()
        {
            return DateTime.Now.Month;
        }

        public static int GetYear()
        {
            return DateTime.Now.Year;
        }
        
        public static int GetDay()
        {
            return DateTime.Now.Day;
        }
    }
}