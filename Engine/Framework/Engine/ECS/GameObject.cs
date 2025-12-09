using System;

namespace Hybrid
{
    public partial class GameObject : Behaviour
    {
        private List<Component> Components { get; set; } = new List<Component>();
        public Scene Scene { get; private set; }
        public bool Enabled { get; set; }
        
        public string Layer { get; set; }
        public string Tag { get; set; }
        
        
        public GameObject(string name = null)
        {
            // Assign
            GameObject = this;
            Name = name ?? Name;

            // Create Transform
            Transform = AddComponentInternal(new Transform
            {
                GameObject = this,
                Name = Name
            });
            
            // Add To Scene
            Scene = Scenes.GetActiveScene();
            Scene.AddObject(this);
            
            // Activate
            Enabled = true;
        }

        // Dispose
        internal override void OnDispose()
        {
            // Destroy All Components
            foreach (var component in GameObject.GetComponents())
            {
                Destroy(component);
            }

            Scene.RemoveObject(GameObject);
            base.OnDispose();
        }
    }

    // Add Component
    public partial class GameObject
    {
        public Component AddComponent(Type type)
        {
            return AddComponentInternal((Component)Activator.CreateInstance(type));
        }
        
        public T AddComponent<T>() where T : Component
        {
            return AddComponentInternal((Component)Activator.CreateInstance(typeof(T))) as T;
        }

        internal T AddComponentInternal<T>(T component) where T : Component
        {
            // Invalid Component
            if (component == null) return null;
            
            // Component Type
            var type = component.GetType();
            
            // Invalid Component
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");
            
            // Disallow Multiple Component
            if (Attribute.IsDefined(type, typeof(DisallowMultipleComponentAttribute)))
            {
                if (GetComponent<T>())
                {
                    throw new Exception($"Can't have multiple instances of '{type.Name}' on GameObject '{GameObject.Name}'");
                }
            }

            // Add To GameObject
            component.GameObject = this.GameObject;
            component.Transform = this.Transform;
            component.Name = this.Name;
            Components.Add(component);
            
            // Require Component
            if (Attribute.IsDefined(type, typeof(RequireComponentAttribute)))
            {
                // For Each Required Component
                foreach (RequireComponentAttribute required in type.GetCustomAttributes(typeof(RequireComponentAttribute), true))
                {
                    if (!GetComponent(required.Type))
                    {
                        // Add Component
                        AddComponent(required.Type);
                    }
                }
            }
            
            Debug.Log($"Component '{component.GetType()}' added to GameObject '{GameObject.Name}'");
            return component;
        }
    }

    // Get Component
    public partial class GameObject
    {
        public Component GetComponent(Type type)
        {
            return GetComponentInternal(type);
        }

        public T GetComponent<T>() where T : Component
        {
            return GetComponentInternal(typeof(T)) as T;
        }
        
        internal Component GetComponentInternal(Type type)
        {
            // Invalid Component
            if (type == null) return null;
            
            // Invalid Component
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");
            
            // Find Matching Component
            foreach (var c in GetComponents())
            {
                if (type.IsAssignableFrom(c.GetType()))
                {
                    return c;
                }
            }

            return null;
        }
    }
    
    // Get Components
    public partial class GameObject
    {
        public Component[] GetComponents(Type type)
        {
            return GetComponentsInternal(type);
        }

        public T[] GetComponents<T>() where T : Component
        {
            return GetComponentsInternal(typeof(T)).Cast<T>().ToArray();
        }
        
        internal Component[] GetComponentsInternal(Type type)
        {
            // Invalid Component
            if (type == null) return Array.Empty<Component>();
            
            // Invalid Component
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");

            // Create Results
            var results = new List<Component>();
            
            // Find All Matching Components
            foreach (var c in GetComponents())
            {
                if (type.IsAssignableFrom(c.GetType()))
                {
                    results.Add(c);
                }
            }

            return results.ToArray();
        }
    }
    
    // Get Component In Children
    public partial class GameObject
    {
        public Component GetComponentInChildren(Type type, bool parent = false)
        {
            return GetComponentInChildrenInternal(type, parent);
        }

        public T GetComponentInChildren<T>(bool parent = false) where T : Component
        {
            return GetComponentInChildrenInternal(typeof(T), parent) as T;
        }
        
        internal Component GetComponentInChildrenInternal(Type type, bool parent = false)
        {
            // Invalid Component
            if (type == null) return null;
            
            // Invalid Component
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");
            
            // Find Matching Component
            foreach (var child in Transform.GetChildrenRecursive(parent))
            {
                foreach (var childComponent in child.GameObject.GetComponents())
                {
                    if (type.IsAssignableFrom(childComponent.GetType()))
                    {
                        return childComponent;
                    }
                }
            }

            return null;
        }
    }
    
    // Get Components In Children
    public partial class GameObject
    {
        public Component[] GetComponentsInChildren(Type type, bool parent = false)
        {
            return GetComponentsInChildrenInternal(type, parent);
        }

        public T[] GetComponentsInChildren<T>(bool parent = false) where T : Component
        {
            return GetComponentsInChildrenInternal(typeof(T), parent).Cast<T>().ToArray();
        }
        
        internal Component[] GetComponentsInChildrenInternal(Type type, bool parent = false)
        {
            // Invalid Component
            if (type == null) return Array.Empty<Component>();
            
            // Invalid Component
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");

            // Create Results
            var results = new List<Component>();
            
            // Find All Matching Components
            foreach (var child in Transform.GetChildrenRecursive(parent))
            {
                foreach (var childComponent in child.GameObject.GetComponents())
                {
                    if (type.IsAssignableFrom(childComponent.GetType()))
                    {
                        results.Add(childComponent);
                    }
                }
            }

            return results.ToArray();
        }
    }
    
    // Get Component In Parent
    public partial class GameObject
    {
        public Component GetComponentInParent(Type type)
        {
            return GetComponentInParentInternal(type);
        }

        public T GetComponentInParent<T>() where T : Component
        {
            return GetComponentInParentInternal(typeof(T)) as T;
        }
        
        internal Component GetComponentInParentInternal(Type type)
        {
            // Invalid Component
            if (type == null) return null;
            
            // Invalid Component
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");
            
            // Find Matching Component
            if (Transform.GetParent())
            {
                foreach (var c in Transform.GetParent().GameObject.GetComponents())
                {
                    if (type.IsAssignableFrom(c.GetType()))
                    {
                        return c;
                    }
                }
            }

            return null;
        }
    }
    
    // Get Components In Parent
    public partial class GameObject
    {
        public Component[] GetComponentsInParent(Type type)
        {
            return GetComponentsInParentInternal(type);
        }

        public T[] GetComponentsInParent<T>() where T : Component
        {
            return GetComponentsInParentInternal(typeof(T)).Cast<T>().ToArray();
        }
        
        internal Component[] GetComponentsInParentInternal(Type type)
        {
            // Invalid Component
            if (type == null) return Array.Empty<Component>();
            
            // Invalid Component
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");

            // Create Results
            var results = new List<Component>();
            
            // Find All Matching Components
            if (Transform.GetParent())
            {
                foreach (var c in Transform.GetParent().GameObject.GetComponents())
                {
                    if (type.IsAssignableFrom(c.GetType()))
                    {
                        results.Add(c);
                    }
                }
            }

            return results.ToArray();
        }
    }
    
    // Destroy Component
    public partial class GameObject
    {
        internal bool DestroyComponent(Type type)
        {
            return DestroyComponentInternal(GetComponent(type));
        }
        
        internal bool DestroyComponent<T>() where T : Component
        {
            return DestroyComponentInternal(GetComponent<T>());
        }

        internal bool DestroyComponentInternal<T>(T component) where T : Component
        {
            // Invalid Component
            if (component == null) return false;
            
            // Component Type
            var type = component.GetType();
            
            // Invalid Component
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");

            // Check For Component
            if (GetComponents().Contains(component))
            {
                // Disallow Destroy Component
                if (Attribute.IsDefined(type, typeof(DisallowDestroyComponentAttribute)))
                {
                    if (!GameObject.IsDestroying())
                    {
                        throw new Exception($"Can't destroy Component '{type.Name}' on GameObject '{GameObject.Name}' because it isn't destroyable");
                    }
                }
                
                // Require Component
                if (!GameObject.IsDestroying())
                {
                    // For Each Component
                    foreach (var checkComponent in GetComponents())
                    {
                        // For Each Required Component
                        foreach (RequireComponentAttribute required in checkComponent.GetType().GetCustomAttributes(typeof(RequireComponentAttribute), true))
                        {
                            if (required.Type == type)
                            {
                                throw new Exception($"Can't destroy Component '{type.Name}' on GameObject '{GameObject.Name}' because Component '{checkComponent.GetType().Name}' requires it");
                            }
                        }
                    }
                }
                
                // Remove From GameObject
                Components.Remove(component);
                Destroy(component);
                
                Debug.Log($"Component '{type.Name}' destroy on GameObject '{GameObject.Name}'");
                return true;
            }

            return false;
        }
    }
    
    // Get All Components
    public partial class GameObject
    {
        public Component[] GetComponents()
        {
            return Components.ToArray();
        }
    }
}