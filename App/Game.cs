using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            Application.TargetFrameRate = 60;
            
            var player = new GameObject("GameObject").AddComponent<Player>();
            var coroutine = player.StartCoroutine(player.Example1(3));
        }

        public override void OnSceneClose()
        {
            
        }
    }
}