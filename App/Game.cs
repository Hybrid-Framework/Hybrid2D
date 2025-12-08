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
            obj1.AddComponent<TestComponent2>();
            Object.Destroy(obj1);
        }

        public override void OnSceneClose()
        {
            
        }
    }
}