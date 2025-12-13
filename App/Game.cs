using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            var gameObject = new GameObject("Parent");
            var player = gameObject.AddComponent<Player>();
            player.StartCoroutine("Example1");
        }

        public override void OnSceneClose()
        {
            
        }
    }
}