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
            GameObject gameObject = new GameObject();
            GameObject child = new GameObject();
            child.Transform.SetParent(gameObject.Transform);
            
            Object.DestroyImmediate(gameObject);

            Debug.Log("Scene: " + gameObject.GetScene()?.Name);
        }

        public override void OnSceneClose()
        {
            
        }
    }
}