using System;

namespace Hybrid
{
    // Transform
    public class Transform : Component
    {
        public Vector2 Position;
        public Vector2 Scale;
        public int Rotation;
        
        
        public override void Awake()
        {
            Console.WriteLine("Transform Awake");
        }

        public override void Start()
        {
            Console.WriteLine("Transform Start");
        }

        public override void Update()
        {
            Console.WriteLine("Transform Update");
        }
    }
}