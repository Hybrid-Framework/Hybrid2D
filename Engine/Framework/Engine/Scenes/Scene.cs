using System;

namespace Hybrid
{
    // Scene API
    public abstract class Scene
    {
        internal HashSet<GameObject> RootGameObjects { get; set; } = new HashSet<GameObject>();
        internal string Name { get; set; }
        internal int Index { get; set; }
        
        
        public List<GameObject> GetRootGameObjects()
        {
            return RootGameObjects.ToList();
        }
        
        public virtual void OnSceneOpen()
        {
            // Called when scene finished opening
        }

        public virtual void OnSceneClose()
        {
            // Called when scene finished closing
        }

        public string GetName()
        {
            return Name;
        }
        
        public int GetIndex()
        {
            return Index;
        }
    }
}