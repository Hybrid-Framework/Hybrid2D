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
                    return "Null";
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
                    return "Null";
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
            if (Scenes.GetActiveScene() == null)
            {
                throw new Exception("Can't create GameObject's with no scene loaded\n" + "You should only create objects in 'OnSceneOpen' or after the scene has loaded");
            }
            
            // GameObject
            GameObject = this;
            
            // Transform
            Transform = AddComponent<Transform>();
            Transform.GameObject = GameObject;
            Transform.Transform = Transform;
            
            // Name
            Name = name ?? Name;
            
            // Scene
            Scenes.AddObject(this);
        }

        // Dispose
        internal override void OnDispose()
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