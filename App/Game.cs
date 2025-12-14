using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            var gameObject = new GameObject();
            var player = gameObject.AddComponent<Player>();
        }

        public override void OnSceneClose()
        {
            
        }
    }
}