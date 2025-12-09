using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            GameObject obj = new GameObject("Object");
            Object.Destroy(obj);
        }

        public override void OnSceneClose()
        {
            
        }
    }
}