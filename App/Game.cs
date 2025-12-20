using System;
using Hybrid;
using Object = Hybrid.Object;

namespace App
{
    [Scene("Game", index: 0)]
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            GameObject gameObject = new GameObject("Parent");
            GameObject child1 = new GameObject("Child 1");
            GameObject child2 = new GameObject("Child 2");
            
            child2.Transform.SetParent(child1.Transform);
            child1.Transform.SetParent(gameObject.Transform);
        }

        public override void OnSceneClose()
        {
            
        }
    }
}