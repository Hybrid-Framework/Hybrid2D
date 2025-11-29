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

            foreach (var component in obj1.GetComponents())
            {
                Console.WriteLine(component.GetType());
            }
        }

        public override void OnSceneClose()
        {
            
        }
    }
}