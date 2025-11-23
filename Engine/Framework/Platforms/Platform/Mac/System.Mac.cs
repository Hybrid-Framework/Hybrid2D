using System;

namespace Hybrid
{
    public class MacSystem : IPlatformSystem
    {
        public System GetSystem()
        {
            return System.Mac;
        }
    }
}