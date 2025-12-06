using System;
using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            GameObject obj1 = new GameObject("Obj 1");
            GameObject obj2 = new GameObject("Obj 2");
        }

        public override void OnSceneClose()
        {
            
        }
    }
}