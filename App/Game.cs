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
            var transform = obj1.GetComponent<Transform>();
            var t1 = obj1.AddComponent(typeof(Transform)) as Transform;
            var t2 = obj1.AddComponent(typeof(Transform)) as Transform;
            var t3 = obj1.AddComponent(typeof(Transform)) as Transform;
            
            Object.Destroy(transform);
        }

        public override void OnSceneClose()
        {
            
        }
    }
}