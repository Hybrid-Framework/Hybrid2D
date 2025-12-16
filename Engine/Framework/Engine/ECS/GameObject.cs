using System;

namespace Hybrid
{
    // GameObject
    public sealed partial class GameObject : Behaviour
    {
        internal List<Component> Components { get; private set; } = new List<Component>();
        internal Scene Scene { get; set; }
        
        private string _Layer { get; set; } = "Default";
        public string Layer
        {
            get
            {
                if (IsDestroyed(this))
                {
                    return "Destroyed";
                }

                return _Layer;
            }
            set
            {
                if (!IsDestroyed(this))
                {
                    _Layer = value;
                }
            }
        }
        
        private string _Tag { get; set; } = "Default";
        public string Tag
        {
            get
            {
                if (IsDestroyed(this))
                {
                    return "Destroyed";
                }

                return _Tag;
            }
            set
            {
                if (!IsDestroyed(this))
                {
                    _Tag = value;
                }
            }
        }
        
        private bool _Active { get; set; } = true;
        public bool Active
        {
            get
            {
                if (IsDestroyed(this))
                {
                    return false;
                }

                return _Active;
            }
            set
            {
                if (!IsDestroyed(this))
                {
                    _Active = value;
                }
            }
        }
        
        
        public GameObject(string name = null)
        {
            // GameObject
            GameObject = this;
            
            // Transform
            Transform = AddComponent<Transform>();
            Transform.GameObject = GameObject;
            Transform.Transform = Transform;
            
            // Scene
            Scenes.AddObject(this);
            
            // Name
            Name = name ?? Name;
        }

        // Dispose
        internal override void OnDispose()
        {
            if (!IsDestroyed(this))
            {
                // For Each Child In GameObject
                foreach (var child in Transform.GetChildrenRecursive())
                {
                    // Destroy Child GameObject
                    Destroy(child.GameObject);
                }
                
                // For Each Component In GameObject
                foreach (var component in GetComponents())
                {
                    // Destroy Component
                    Destroy(component);
                }
                
                // Remove From Scene
                Scenes.RemoveObject(this);
            }
        }
    }

    // GameObject
    public partial class GameObject
    {
        public void SetActive(bool active)
        {
            if (!IsDestroyed(this))
            {
                Active = active;
            }
        }
        
        public Scene GetScene()
        {
            if (!IsDestroyed(this))
            {
                return Scene;
            }

            return null;
        }

        public GameObject Find(string name)
        {
            if (!IsDestroyed(this))
            {
                foreach (Transform child in Transform.GetChildrenRecursive(true))
                {
                    if (child.Name == name)
                    {
                        return child.GameObject;
                    }
                }
            }

            return null;
        }
    }
}