using System;

namespace Hybrid
{
    [RequireComponent(typeof(TestComponent2))]
    public class TestComponent : Component
    {
        public override void OnAwake()
        {
            Console.WriteLine("OnAwake");
        }
        
        public override void OnStart()
        {
            Console.WriteLine("OnStart");
        }
        
        public override void OnEnable()
        {
            Console.WriteLine("OnEnable");
        }
        
        public override void OnDisable()
        {
            Console.WriteLine("OnDisable");
        }
        
        public override void OnUpdate()
        {
            // Console.WriteLine("OnUpdate");
        }
        
        public override void OnFixedUpdate()
        {
            // Console.WriteLine("OnFixedUpdate");
        }
        
        public override void OnLateUpdate()
        {
            // Console.WriteLine("OnLateUpdate");
        }
        
        public override void OnDestroy()
        {
            Console.WriteLine("OnDestroy");
        }
    }
}