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