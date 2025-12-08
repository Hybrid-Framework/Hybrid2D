using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            GameObject obj1 = new GameObject("Obj 1");
            Object.Destroy(obj1);
        }

        public override void OnSceneClose()
        {
            
        }
    }
}