using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            var player = new GameObject().AddComponent<Player>();
            player.StartInvoke("InvokeExample1", 1, 1);
            player.StartInvoke("InvokeExample2", 1, 1);
            player.StartInvoke("InvokeExample3", 1, 1);
            player.StopInvoke("InvokeExample1");
            player.StopAllInvokes();
        }

        public override void OnSceneClose()
        {
            
        }
    }
}