using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            var player = new GameObject().AddComponent<Player>();
            player.StartInvokeRepeating("InvokeExample1", 1, 1);
            player.StartInvokeRepeating("InvokeExample2", 1, 1);
            player.StopInvoke("InvokeExample2");
        }

        public override void OnSceneClose()
        {
            
        }
    }
}