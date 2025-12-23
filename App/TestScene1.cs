using Hybrid;

namespace App
{
    [Scene("Test Scene 1", index: 1)]
    public class TestScene1 : Scene
    {
        public override void OnSceneOpen()
        {
            GameObject gameObject = new GameObject("Obj");

            Layers.CreateLayer("Layer 1");
            Layers.CreateLayer("Layer 2");
            Layers.CreateLayer("Layer 3");
            
            gameObject.Layer.Set(Layers.Everything);
            gameObject.Layer.Set(Layers.Nothing);
            
            gameObject.Layer.ResetToDefault();
            
            Debug.Log(gameObject.Layer);
        }

        public override void OnSceneClose()
        {
            
        }
    }
}