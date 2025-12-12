using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            var gameObject = new GameObject("Parent");
            var component = gameObject.AddComponent<TestComponent>();

            gameObject.Name = "Test 1";
            component.Name = "Test 2";
            
            Object.Destroy(gameObject);
            
            Debug.Log(component.Name);
            Debug.Log(gameObject.Name);
        }

        public override void OnSceneClose()
        {
            
        }
    }
}