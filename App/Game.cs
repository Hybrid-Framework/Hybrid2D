using System;
using Hybrid;
using Object = Hybrid.Object;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            var gameObject = new GameObject();
            Object.Destroy(gameObject);
            gameObject.Name = "Hello";

            throw new Exception("Failed");
        }

        public override void OnSceneClose()
        {
            
        }
    }
}