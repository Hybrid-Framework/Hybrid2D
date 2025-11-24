using System;

namespace Hybrid
{
    // Resources
    public class Resources : Module
    {
        internal Resources(Config config)
        {
            
        }

        internal override void OnDestroy()
        {
            Console.WriteLine("Resources Disposed");
        }
    }
}