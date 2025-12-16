using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            var gameObject = new GameObject();
            var player = gameObject.AddComponent<Player>();
            Object.Destroy(player);
            Debug.Log(gameObject);
            Debug.Log(player);
        }

        public override void OnSceneClose()
        {
            
        }
    }
}