using System;
using Hybrid;
using Object = Hybrid.Object;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            Application.TargetFrameRate = 0;
            Application.VSync = true;
            
            GameObject obj = new GameObject("Object");
            Object.Destroy(obj);
        }

        public override void OnSceneClose()
        {
            
        }
    }
}