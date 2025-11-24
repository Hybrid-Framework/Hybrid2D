using System;
using Hybrid;
using Object = Hybrid.Object;

namespace App
{
    public class Scene : Hybrid.Scene
    {
        public override void OnSceneOpen()
        {
            var texture1 = Resources.Load<Texture>("Images/Image.png");
            var texture2 = Resources.Load<Texture>("Images/Image.png");
            var texture3 = Resources.Load<Texture>("Images/Image.png");
        }

        public override void OnSceneClose()
        {
            
        }
    }
}