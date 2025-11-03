using System;
using Hybrid;

namespace App
{
    public class Scene : Hybrid.Scene
    {
        public override void OnOpened()
        {
            Entity obj1 = new Entity("Hello");
            obj1.Destroy();
            
            obj1.GetComponent<Transform>();
        }

        public override void OnClosed()
        {
            
        }
    }
}