using System;

namespace Hybrid
{
    // GameObject
    public sealed partial class GameObject : Behaviour
    {
        internal List<Component> Components { get; private set; } = new List<Component>();
        internal Scene Scene { get; private set; } = null;
        public string Layer { get; set; } = "Default";
        public string Tag { get; set; } = "Default";
        public bool Active { get; set; } = true;
        
        
        // Constructor
        public GameObject(string name = null)
        {
            // Properties
            Name = name ?? Name;
            GameObject = this;
            
            // Create Transform
            Transform = AddComponent<Transform>();
            Transform.GameObject = GameObject;
            Transform.Transform = Transform;
            Transform.Name = Name;
            
            // Add To Scene
            Scene = Scenes.GetActiveScene();
            Scene.AddObject(this);
        }

        // Dispose
        internal override void OnDispose()
        {
            if (!IsDestroyed())
            {
                // For Each Child In GameObject
                foreach (var child in Transform.GetChildrenRecursive())
                {
                    // Destroy Child GameObject
                    Object.Destroy(child.GameObject);
                }
                
                // For Each Component In GameObject
                foreach (var component in GetComponents())
                {
                    // Destroy Component
                    Object.Destroy(component);
                }
                
                // Remove From Scene
                Scene.RemoveObject(GameObject);
            }
            
            base.OnDispose();
        }
    }

    // GameObject
    public partial class GameObject
    {
        public void SetActive(bool active)
        {
            Active = active;
        }
        
        public Scene GetScene()
        {
            return Scene;
        }

        public GameObject Find(string name)
        {
            foreach (Transform child in Transform.GetChildrenRecursive(true))
            {
                if (child.Name == name)
                {
                    return child.GameObject;
                }
            }

            return null;
        }
    }
}