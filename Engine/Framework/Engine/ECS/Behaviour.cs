using System;

namespace Hybrid
{
    public abstract partial class Behaviour : Object
    {
        public GameObject GameObject { get; internal set; }
        public Transform Transform { get; internal set; }
        
        private bool _Enabled { get; set; } = true;
        public bool Enabled
        {
            get => _Enabled;
            set
            {
                if (this is Component component)
                {
                    if (value != _Enabled)
                    {
                        if(value) component.OnEnable();
                        if(!value) component.OnDisable();
                    }
                }

                _Enabled = value;
            }
        }
    }

    // Find Object Types
    public abstract partial class Behaviour
    {
        public static GameObject[] FindGameObjectsByName(string name)
        {
            List<GameObject> results = new();
            
            foreach (var gameObject in Scenes.GetActiveScene().GetRootGameObjects())
            {
                foreach (var child in gameObject.Transform.GetChildrenRecursive(true))
                {
                    if (child.GameObject.Name == name)
                    {
                        results.Add(child.GameObject);
                    }
                }
            }
            
            return results.ToArray();
        }
        
        public static GameObject FindGameObjectByName(string name)
        {
            foreach (var gameObject in Scenes.GetActiveScene().GetRootGameObjects())
            {
                foreach (var child in gameObject.Transform.GetChildrenRecursive(true))
                {
                    if (child.GameObject.Name == name)
                    {
                        return child.GameObject;
                    }
                }
            }
            
            return null;
        }
        
        public static GameObject[] FindGameObjectsByLayer(string layer)
        {
            List<GameObject> results = new();
            
            foreach (var gameObject in Scenes.GetActiveScene().GetRootGameObjects())
            {
                foreach (var child in gameObject.Transform.GetChildrenRecursive(true))
                {
                    if (child.GameObject.Layer == layer)
                    {
                        results.Add(child.GameObject);
                    }
                }
            }
            
            return results.ToArray();
        }
        
        public static GameObject FindGameObjectByLayer(string layer)
        {
            foreach (var gameObject in Scenes.GetActiveScene().GetRootGameObjects())
            {
                foreach (var child in gameObject.Transform.GetChildrenRecursive(true))
                {
                    if (child.GameObject.Layer == layer)
                    {
                        return child.GameObject;
                    }
                }
            }
            
            return null;
        }
        
        public static GameObject[] FindGameObjectsByTag(string tag)
        {
            List<GameObject> results = new();
            
            foreach (var gameObject in Scenes.GetActiveScene().GetRootGameObjects())
            {
                foreach (var child in gameObject.Transform.GetChildrenRecursive(true))
                {
                    if (child.GameObject.Tag == tag)
                    {
                        results.Add(child.GameObject);
                    }
                }
            }
            
            return results.ToArray();
        }
        
        public static GameObject FindGameObjectByTag(string tag)
        {
            foreach (var gameObject in Scenes.GetActiveScene().GetRootGameObjects())
            {
                foreach (var child in gameObject.Transform.GetChildrenRecursive(true))
                {
                    if (child.GameObject.Tag == tag)
                    {
                        return child.GameObject;
                    }
                }
            }

            return null;
        }

        public static T[] FindObjectsByType<T>() where T : Object
        {
            List<T> results = new();
            
            foreach (var gameObject in Scenes.GetActiveScene().GetRootGameObjects())
            {
                foreach (var child in gameObject.Transform.GetChildrenRecursive(true))
                {
                    if (child.GameObject is T g)
                    {
                        results.Add(g);
                    }
                    
                    if (child.Transform is T t)
                    {
                        results.Add(t);
                    }

                    foreach (var component in child.GetComponents())
                    {
                        if (component is T c)
                        {
                            results.Add(c);
                        }
                    }
                }
            }
            
            return results.ToArray();
        }
        
        public static T FindObjectByType<T>() where T : Object
        {
            foreach (var gameObject in Scenes.GetActiveScene().GetRootGameObjects())
            {
                foreach (var child in gameObject.Transform.GetChildrenRecursive(true))
                {
                    if (child.GameObject is T g)
                    {
                        return g;
                    }
                    
                    if (child.Transform is T t)
                    {
                        return t;
                    }

                    foreach (var component in child.GetComponents())
                    {
                        if (component is T c)
                        {
                            return c;
                        }
                    }
                }
            }

            return null;
        }
    }
    
    // Add Component
    public abstract partial class Behaviour
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
            if (component == null || GameObject == null) return null;
            
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

            // Set Properties
            component.GameObject = this.GameObject;
            component.Transform = this.Transform;
            component.Name = this.Name;
            
            // Add To GameObject
            GameObject.Components.Add(component);
            
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
    public abstract partial class Behaviour
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
            if (type == null || GameObject == null) return null;
            
            // Invalid Component
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");
            
            // Find Matching Component
            foreach (var component in GetComponents())
            {
                if (type.IsAssignableFrom(component.GetType()))
                {
                    return component;
                }
            }

            return null;
        }
    }
    
    // Get Components
    public abstract partial class Behaviour
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
            if (type == null || GameObject == null) return Array.Empty<Component>();
            
            // Invalid Component
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");

            // Create Results
            var results = new List<Component>();
            
            // Find All Matching Components
            foreach (var component in GetComponents())
            {
                if (type.IsAssignableFrom(component.GetType()))
                {
                    results.Add(component);
                }
            }

            return results.ToArray();
        }
    }
    
    // Get Component In Children
    public abstract partial class Behaviour
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
            if (type == null || GameObject == null) return null;
            
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
    public abstract partial class Behaviour
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
            if (type == null || GameObject == null) return Array.Empty<Component>();
            
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
    public abstract partial class Behaviour
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
            if (type == null || GameObject == null) return null;
            
            // Invalid Component
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");
            
            // Find Matching Component
            if (Transform.GetParent())
            {
                foreach (var parentComponent in Transform.GetParent().GameObject.GetComponents())
                {
                    if (type.IsAssignableFrom(parentComponent.GetType()))
                    {
                        return parentComponent;
                    }
                }
            }

            return null;
        }
    }
    
    // Get Components In Parent
    public abstract partial class Behaviour
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
            if (type == null || GameObject == null) return Array.Empty<Component>();
            
            // Invalid Component
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");

            // Create Results
            var results = new List<Component>();
            
            // Find All Matching Components
            if (Transform.GetParent())
            {
                foreach (var parentComponent in Transform.GetParent().GameObject.GetComponents())
                {
                    if (type.IsAssignableFrom(parentComponent.GetType()))
                    {
                        results.Add(parentComponent);
                    }
                }
            }

            return results.ToArray();
        }
    }
    
    // Destroy Component
    public abstract partial class Behaviour
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
            if (component == null || GameObject == null) return false;
            
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
                GameObject.Components.Remove(component);
                Debug.Log($"Component '{type.Name}' destroy on GameObject '{GameObject.Name}'");
                return true;
            }

            return false;
        }
    }
    
    // Get All Components
    public abstract partial class Behaviour
    {
        public Component[] GetComponents()
        {
            // Invalid GameObject
            if (GameObject == null)
            {
                return Array.Empty<Component>();
            }
            
            return GameObject.Components.ToArray();
        }
    }
}