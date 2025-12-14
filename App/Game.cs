using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            var player = new GameObject().AddComponent<Player>();
            var coroutine = player.StartCoroutine(player.Example1(3));
        }

        public override void OnSceneClose()
        {
            
        }
    }
}