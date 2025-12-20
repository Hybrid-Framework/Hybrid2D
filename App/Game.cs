using System;
using Hybrid;

namespace App
{
    [Scene("Game", index: 0)]
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            GameObject gameObject = new GameObject("GameObj");
            Scenes.LoadScene(1, SceneMode.Single);
        }

        public override void OnSceneClose()
        {
            
        }
    }
}