using System;

namespace Hybrid
{
    public class WebSystem : IPlatformSystem
    {
        public System GetSystem()
        {
            return System.Web;
        }
    }
}