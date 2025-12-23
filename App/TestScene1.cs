using Hybrid;

namespace App
{
    [Scene("Test Scene 1", index: 1)]
    public class TestScene1 : Scene
    {
        public override void OnSceneOpen()
        {
            GameObject parent = new GameObject("Parent");
            
            Scenes.LoadScene(Scenes.GetSceneByIndex(2).Name, LoadSceneMode.Additive);
            
            GameObject child = new GameObject("Child");
            GameObject sub = new GameObject("Sub");
            sub.Transform.SetParent(child.Transform);
            child.Transform.SetParent(parent.Transform);
            
            Debug.Log(parent.GetScene());
            Debug.Log(child.GetScene());
            Debug.Log(sub.GetScene());
            
            Debug.Log(child.Transform.GetRootParent().Name);
            Debug.Log(parent.Transform.GetRootParent().Name);
            Debug.Log(sub.Transform.GetRootParent().Name);
        }

        public override void OnSceneClose()
        {
            
        }
    }
}