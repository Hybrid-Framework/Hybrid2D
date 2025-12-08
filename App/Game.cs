using System;
using Hybrid;
using Object = Hybrid.Object;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            GameObject obj1 = new GameObject("Obj 1");
            var component = obj1.AddComponent<TestComponent>();
        }

        public override void OnSceneClose()
        {
            
        }
    }
}