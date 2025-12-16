using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            var gameObject = new GameObject();
            var player = gameObject.AddComponent<Player>();
            gameObject.Name = "Hello";
            
            Object.Destroy(gameObject);
            
            Debug.Log(gameObject.Name);
            Debug.Log(player.Name);
            Debug.Log(gameObject);
            Debug.Log(player);
        }

        public override void OnSceneClose()
        {
            
        }
    }
}