using System;

namespace Hybrid
{
    public abstract class Scene
    {
        internal List<GameObject> SceneGameObjects = new List<GameObject>();
        
        public abstract void OnOpened();
        public abstract void OnClosed();
        

        internal void Add(GameObject gameObject)
        {
            SceneGameObjects.Add(gameObject);
            Console.WriteLine($"GameObject '{gameObject.Name}' added to '{this}'");
        }

        internal void Remove(GameObject gameObject)
        {
            SceneGameObjects.Remove(gameObject);
            Console.WriteLine($"GameObject '{gameObject.Name}' removed from '{this}'");
        }

        public GameObject[] GetSceneObjects()
        {
            return SceneGameObjects.ToArray();
        }
        
        public override string ToString()
        {
            return GetType().Name;
        }
    }
}