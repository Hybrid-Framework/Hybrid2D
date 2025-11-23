using System;

namespace Hybrid
{
    public class LinuxSystem : IPlatformSystem
    {
        public System GetSystem()
        {
            return System.Linux;
        }
    }
}