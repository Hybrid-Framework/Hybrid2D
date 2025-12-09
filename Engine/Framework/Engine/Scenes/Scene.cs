using System;

namespace Hybrid
{
    // Internal
    public abstract partial class Scene
    {
        private readonly List<GameObject> RootGameObjects = new List<GameObject>();
        

        internal void AddObject(GameObject gameObject)
        {
            Debug.Log($"Added '{gameObject.Name}' to scene root GameObjects");
            RootGameObjects.Add(gameObject);
        }

        internal void RemoveObject(GameObject gameObject)
        {
            Debug.Log($"Removed '{gameObject.Name}' from scene root GameObjects");
            RootGameObjects.Remove(gameObject);
        }
    }

    // Scene API
    public abstract partial class Scene
    {
        public string Name
        {
            get => GetType().Name;
        }
        
        
        public GameObject[] GetRootGameObjects()
        {
            return RootGameObjects.ToArray();
        }
        
        public virtual void OnSceneOpen()
        {
            
        }

        public virtual void OnSceneClose()
        {
            
        }
    }
}