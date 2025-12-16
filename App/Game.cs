using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            var gameObject = new GameObject();
            Object.Destroy(gameObject);

            gameObject.Name = "Hello";
            Debug.Log(gameObject.Name);
        }

        public override void OnSceneClose()
        {
            
        }
    }
}