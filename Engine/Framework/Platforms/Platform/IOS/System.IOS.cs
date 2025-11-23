using System;

namespace Hybrid
{
    public class IOSSystem : IPlatformSystem
    {
        public System GetSystem()
        {
            return System.IOS;
        }
    }
}