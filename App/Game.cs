using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            Transform parent = new GameObject("ParentObj").Transform;
            Transform one = new GameObject("One").Transform;
            Transform two = new GameObject("Two").Transform;
            Transform three = new GameObject("Three").Transform;
            
            one.SetParent(parent);
            two.SetParent(parent);
            three.SetParent(parent);

            foreach (var c in parent.GetChildren())
            {
                Debug.Log(c.Name);
            }
        }

        public override void OnSceneClose()
        {
            
        }
    }
}