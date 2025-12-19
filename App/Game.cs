using Hybrid;

namespace App
{
    [Scene("Game", index: 0)]
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            GameObject gameObject = new GameObject("Hello");
            Object.Destroy(gameObject);

            gameObject.Name = "V2";
            Debug.Log(gameObject.Name);
        }

        public override void OnSceneClose()
        {
            
        }
    }
}