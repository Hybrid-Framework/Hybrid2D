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
            
            var test1 = obj1.AddComponent(typeof(TestComponent));
            var test2 = obj1.AddComponent<TestComponent>();

            foreach (var comp in obj1.GetComponents())
            {
                Object.Destroy(comp);
            }
        }

        public override void OnSceneClose()
        {
            
        }
    }
}