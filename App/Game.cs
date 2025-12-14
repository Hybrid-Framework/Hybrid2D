using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            var player = new GameObject().AddComponent<Player>();
            player.InvokeRepeating("InvokeExample1", 1, 1);
            player.Invoke("InvokeExample1", 0);
            player.Invoke("InvokeExample2", 0);
        }

        public override void OnSceneClose()
        {
            
        }
    }
}