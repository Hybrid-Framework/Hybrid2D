using System;
using Hybrid;
using Object = Hybrid.Object;

namespace App
{
    [Scene("Game", index: 0)]
    public class GameScene : Scene
    {
        private readonly Transform transform = new GameObject("Game hi").GetComponent<Transform>();
        
        public override void OnSceneOpen()
        {
            Object.Destroy(transform);
        }

        public override void OnSceneClose()
        {
            Debug.Log($"Null: {transform == null}");
            Debug.Log($"IsDestroyed: {Object.IsDestroyed(transform)}");
            Debug.Log($"IsDestroying: {Object.IsDestroying(transform)}");
        }
    }
}