using System;

namespace Hybrid
{
    public class AndroidSystem : IPlatformSystem
    {
        public System GetSystem()
        {
            return System.Android;
        }
    }
}