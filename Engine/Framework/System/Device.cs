using System;

namespace Hybrid
{
    // Device API
    public static class Device
    {
        public static Platform GetPlatform()
        {
            return SDL.GetPlatform().ToUpper() switch
            {
                "ANDROID" => Platform.Android,
                "WINDOWS" => Platform.Windows,
                "EMSCRIPTEN" => Platform.Web,
                "MACOS" => Platform.MacOS,
                "LINUX" => Platform.Linux,
                "IOS" => Platform.IOS,
                
                _ => Platform.Unknown
            };
        }

        public static string GetOSVersion()
        {
            return Environment.OSVersion.ToString();
        }

        public static string GetMachineName()
        {
            return Environment.MachineName;
        }

        public static int GetProcessorCount()
        {
            return Environment.ProcessorCount;
        }

        public static bool GetProcessor64Bit()
        {
            return Environment.Is64BitProcess;
        }
        
        public static string GetDay()
        {
            return DateTime.Now.ToString("dd");
        }
        
        public static string GetMonth()
        {
            return DateTime.Now.ToString("MM");
        }
        
        public static string GetYear()
        {
            return DateTime.Now.ToString("yyyy");
        }
        
        public static string GetDate()
        {
            return DateTime.Now.ToString("dd-MM-yyyy");
        }

        public static string GetTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }
    }
}