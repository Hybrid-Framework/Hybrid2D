using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            var gameObject = new GameObject("Parent");
            var player = gameObject.AddComponent<Player>();

            // Start
            var coroutine1 = player.StartCoroutine("Example1");
            var coroutine2 = player.StartCoroutine(player.Example1);
            
            // Stop
            // player.StopCoroutine("Example1");
            // player.StopCoroutine(coroutine1);
            
            // Stop All
            // player.StopAllCoroutines();
            
            // Debug Total
            Debug.Log("Total: " + player.GetCoroutinesCount());
        }

        public override void OnSceneClose()
        {
            
        }
    }
}