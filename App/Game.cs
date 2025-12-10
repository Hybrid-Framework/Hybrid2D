using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            GameObject obj1 = new GameObject("Object 1");
            GameObject obj2 = new GameObject("Object 2");
        }

        public override void OnSceneClose()
        {
            
        }
    }
}