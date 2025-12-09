using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            Transform parent = new GameObject("parent").Transform;
            Transform child = new GameObject("child").Transform;
            Transform sub = new GameObject("sub").Transform;
            Transform other = new GameObject("other").Transform;
            
            child.SetParent(parent);
            sub.SetParent(parent);
            other.SetParent(parent);
            
            child.SetSiblingIndex(3);

            for (int i = 0; i < parent.GetChildren().Length; i++)
            {
                Debug.Log($"{i}: " + parent.GetChildren()[i]);
            }
            
            Debug.Log(child.IsChildOf(child));
            
            
            child.SetParent(null);
        }

        public override void OnSceneClose()
        {
            
        }
    }
}