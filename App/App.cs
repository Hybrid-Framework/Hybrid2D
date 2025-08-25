using System;
using Engine;

namespace App
{
    public static class App
    {
        public static void Run()
        {
            #if WINDOWS
            Console.WriteLine("WINDOWS");
            #elif LINUX
            Console.WriteLine("LINUX");
            #elif MACOS
            Console.WriteLine("MACOS");
            #elif ANDROID
            Console.WriteLine("ANDROID");
            #elif IOS
            Console.WriteLine("IOS");
            #elif WEB
            Console.WriteLine("WEB");
            #else
            Console.WriteLine("UNKNOWN");
            #endif
        }
    }
}