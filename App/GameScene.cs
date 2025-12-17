using System;
using Hybrid;
using Object = Hybrid.Object;

namespace App
{
    [Scene("Game", index: 0)]
    public class GameScene : Scene
    {
        private readonly GameObject gameObject = new GameObject("Game hi");
        
        public override void OnSceneOpen()
        {
            Object.DontDestroyOnLoad(gameObject);
        }

        public override void OnSceneClose()
        {
            
        }
    }
}