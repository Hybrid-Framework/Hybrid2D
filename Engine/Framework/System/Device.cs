using System;

namespace Hybrid
{
    // Device API
    public static class Device
    {
        // Get the current platform (Ex: Windows, Android, etc)
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

        // Get operating system version
        public static string GetOSVersion()
        {
            return Environment.OSVersion.ToString();
        }

        // Get processor count
        public static int GetProcessorCount()
        {
            return Environment.ProcessorCount;
        }

        // Is the processor 64 bit
        public static bool GetProcessor64Bit()
        {
            return Environment.Is64BitProcess;
        }
        
        // Get full date
        public static string GetDate()
        {
            return DateTime.Now.ToString("dd-MM-yyyy");
        }

        // Get full time
        public static string GetTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }
        
        // Get month
        public static int GetMonth()
        {
            return DateTime.Now.Month;
        }

        // Get year
        public static int GetYear()
        {
            return DateTime.Now.Year;
        }
        
        // Get day
        public static int GetDay()
        {
            return DateTime.Now.Day;
        }
    }
}