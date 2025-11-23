using System;

namespace Hybrid
{
    public class WindowsSystem : IPlatformSystem
    {
        public System GetSystem()
        {
            return System.Windows;
        }
    }
}