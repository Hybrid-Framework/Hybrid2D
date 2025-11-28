using System;

namespace Hybrid
{
    public class Input : Module<Input>
    {
        private Input() { }

        // Create
        internal override void OnCreate()
        {
            Console.WriteLine("Input Created");
        }

        // Destroy
        internal override void OnDestroy()
        {
            Console.WriteLine("Input Destroyed");
        }
    }
}