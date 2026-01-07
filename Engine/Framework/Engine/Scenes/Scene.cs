using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;

namespace Hybrid
{
    // Scene API
    public abstract class Scene
    {
        internal HashSet<GameObject> RootGameObjects { get; private set; } = new HashSet<GameObject>();

        public bool IsActiveScene => Scenes.GetActiveScene() == this;
        public bool IsLoaded { get; internal set; }
        
        public string Name { get; internal set; }
        public Type Type { get; internal set; }
        public int Index { get; internal set; }
        
        
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