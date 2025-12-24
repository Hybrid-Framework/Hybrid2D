using Hybrid;

namespace App
{
    [Scene("Test Scene 1", index: 1)]
    public class TestScene1 : Scene
    {
        public override void OnSceneOpen()
        {
            Application.TargetFrameRate = 60;
            
            GameObject gameObject = new GameObject("Obj");
            GameObject child = new GameObject("Child");
            child.Transform.SetParent(gameObject.Transform);

            Debug.Log("GameObject: " + gameObject.Scene?.Name);
            Debug.Log("Child: " + child.Scene?.Name);
            
            Object.DestroyImmediate(gameObject);
            
            Debug.Log("GameObject: " + gameObject.Scene?.Name);
            Debug.Log("Child: " + child.Scene?.Name);
        }

        public override void OnSceneClose()
        {
            
        }
    }
}