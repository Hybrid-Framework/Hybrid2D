using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            var gameObject = new GameObject("Parent");
            var component = gameObject.AddComponent<TestComponent>();

            gameObject.Name = "Hello!";
            component.Name = "Hello!";
            
            Object.Destroy(component);
        }

        public override void OnSceneClose()
        {
            
        }
    }
}