using System;

namespace Hybrid
{
    // Scene API
    public abstract partial class Scene
    {
        private readonly List<GameObject> RootGameObjects = new List<GameObject>();
        public string Name => GetType().Name;
        
        
        internal void AddObject(GameObject gameObject)
        {
            // Debug.Log($"Added '{gameObject.Name}' to scene root GameObjects");
            RootGameObjects.Add(gameObject);
        }

        internal void RemoveObject(GameObject gameObject)
        {
            // Debug.Log($"Removed '{gameObject.Name}' from scene root GameObjects");
            RootGameObjects.Remove(gameObject);
        }
        
        public GameObject[] GetRootGameObjects()
        {
            return RootGameObjects.ToArray();
        }
        
        public virtual void OnSceneOpen()
        {
            // Called when scene finished opening
        }

        public virtual void OnSceneClose()
        {
            // Called when scene finished closing
        }
    }
}