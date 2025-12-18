using Hybrid;

namespace App
{
    [Scene("Game", index: 0)]
    public class GameScene : Scene
    {
        public override void OnSceneOpen()
        {
            GameObject gameObject = new GameObject("Hello");
            var test = gameObject.AddComponent<Player>();
            Object.Destroy(gameObject, 1);
        }

        public override void OnSceneClose()
        {
            
        }
    }
}