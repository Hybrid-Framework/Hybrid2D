using Hybrid;

namespace App
{
    [Scene("Game", index: 0)]
    public class GameScene : Scene
    {
        public override void OnSceneOpen()
        {
            GameObject gameObject = new GameObject("Hello");
            var test = gameObject.AddComponent<TestComponent>();
            
            Object.Destroy(gameObject);

            Debug.Log(test.GameObject.Active);
            Debug.Log(test.GameObject.Name);
            Debug.Log(test.Name);
        }

        public override void OnSceneClose()
        {
            
        }
    }
}