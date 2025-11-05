using System;

namespace Hybrid
{
    // Transform
    public class Transform : Component
    {
        public Vector2 Position;
        public Vector2 Scale;
        public int Rotation;

        
        public override void OnStart()
        {
            // Console.WriteLine("OnStart");
        }
        
        public override void OnUpdate()
        {
            // Console.WriteLine("OnUpdate");
        }

        public override void OnEnable()
        {
            // Console.WriteLine("OnEnable");
        }
        
        public override void OnDisable()
        {
            // Console.WriteLine("OnDisable");
        }
        
        public override void OnDestroy()
        {
            // Console.WriteLine("OnDestroy");
        }
    }
}