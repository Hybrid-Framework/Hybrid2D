using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            Transform parent = new GameObject("parent").Transform;
            Transform[] children = new Transform[5];
            
            for (int i = 0; i < children.Length; i++)
            {
                children[i] = new GameObject($"Child {i}").Transform;
                children[i].SetParent(parent);
            }
        }

        public override void OnSceneClose()
        {
            
        }
    }
}