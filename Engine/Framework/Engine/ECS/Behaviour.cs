using System;
using System.Reflection;

namespace Hybrid
{
    public abstract partial class Behaviour : Object
    {
        private readonly HashSet<Type> RequireComponentsProcessing = new();
        
        public GameObject GameObject { get; internal set; }
        public Transform Transform { get; internal set; }
        
        private bool _Enabled { get; set; } = true;
        public bool Enabled
        {
            get => _Enabled;
            set
            {
                if (value != _Enabled && this is Component component)
                {
                    if(value) component.OnEnable();
                    if(!value) component.OnDisable();
                }

                _Enabled = value;
            }
        }
    }

    // Add Component
    public abstract partial class Behaviour
    {
        public Component AddComponent(Type type)
        {
            return AddComponentInternal
            (
                (Component)Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, null, null)
            );
        }
        
        public T AddComponent<T>() where T : Component
        {
            return AddComponentInternal
            (
                (T)Activator.CreateInstance(typeof(T), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, null, null)
            );
        }

        internal T AddComponentInternal<T>(T component) where T : Component
        {
            // Invalid Component
            if (component == null || GameObject == null)
                return null;
            
            // Component Type
            var type = component.GetType();
            
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");
            
            // Disallow Multiple Component
            if (Attribute.IsDefined(type, typeof(DisallowMultipleComponentAttribute)))
            {
                // Has Component
                if (GetComponent<T>())
                {
                    throw new Exception($"Can't have multiple instances of '{type.Name}' on GameObject '{GameObject.Name}'");
                }
            }
            
            // Require Component
            if (Attribute.IsDefined(type, typeof(RequireComponentAttribute)))
            {
                // Processing Component
                if (!GameObject.RequireComponentsProcessing.Add(type))
                    return component;
                
                // For Each Required Component
                foreach (RequireComponentAttribute required in type.GetCustomAttributes(typeof(RequireComponentAttribute), true))
                {
                    // Find Component
                    if (!GetComponent(required.Type))
                    {
                        // Attach & Return
                        AddComponent(required.Type);
                    }
                }
                
                // Finished Processing
                GameObject.RequireComponentsProcessing.Remove(type);
            }

            // Set Properties
            component.GameObject = this.GameObject;
            component.Transform = this.Transform;
            component.Name = this.Name;
            
            // Add To GameObject
            // Debug.Log($"Component '{component.GetType()}' added to GameObject '{GameObject.Name}'");
            GameObject.Components.Add(component);
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
            if (type == null || GameObject == null)
                return null;
            
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");
            
            // For Each Component In GameObject
            foreach (var component in GameObject.Components)
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
        public Component[] GetComponents()
        {
            return GetComponentsInternal(typeof(Component)).ToArray();
        }
        
        public Component[] GetComponents(Type type)
        {
            return GetComponentsInternal(type).ToArray();
        }

        public T[] GetComponents<T>() where T : Component
        {
            return GetComponentsInternal(typeof(T)).Cast<T>().ToArray();
        }
        
        internal Component[] GetComponentsInternal(Type type)
        {
            // Invalid Component
            if (type == null || GameObject == null)
                return Array.Empty<Component>();
            
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");

            // Create Results
            var results = new List<Component>();
            
            // For Each Component In GameObject
            foreach (var component in GameObject.Components)
            {
                if (type.IsAssignableFrom(component.GetType()))
                {
                    results.Add(component);
                }
            }

            return results.ToArray();
        }
    }
    
    // Get Component In Parent
    public abstract partial class Behaviour
    {
        public Component GetComponentInParent(Type type, bool includeSelf = false)
        {
            return GetComponentInParentInternal(type, includeSelf);
        }

        public T GetComponentInParent<T>(bool includeSelf = false) where T : Component
        {
            return GetComponentInParentInternal(typeof(T), includeSelf) as T;
        }
        
        internal Component GetComponentInParentInternal(Type type, bool includeSelf = false)
        {
            // Invalid Component
            if (type == null || GameObject == null)
                return null;
            
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");
            
            // Find Component In Parent
            Transform current = includeSelf ? Transform : Transform.Parent;
            
            while (current != null)
            {
                foreach (var component in current.GameObject.Components)
                {
                    if (type.IsAssignableFrom(component.GetType()))
                    {
                        return component;
                    }
                }
                
                current = current.Parent;
            }

            return null;
        }
    }
    
    // Get Components In Parent
    public abstract partial class Behaviour
    {
        public Component[] GetComponentsInParent(Type type, bool includeSelf = false)
        {
            return GetComponentsInParentInternal(type, includeSelf).ToArray();
        }

        public T[] GetComponentsInParent<T>(bool includeSelf = false) where T : Component
        {
            return GetComponentsInParentInternal(typeof(T), includeSelf).Cast<T>().ToArray();
        }
        
        internal Component[] GetComponentsInParentInternal(Type type, bool includeSelf = false)
        {
            // Invalid Component
            if (type == null || GameObject == null)
                return Array.Empty<Component>();
            
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");

            // Find Component In Parent
            var results = new List<Component>();
            Transform current = includeSelf ? Transform : Transform.Parent;
            
            while (current != null)
            {
                foreach (var component in current.GameObject.Components)
                {
                    if (type.IsAssignableFrom(component.GetType()))
                    {
                        results.Add(component);
                    }
                }
                
                current = current.Parent;
            }

            return results.ToArray();
        }
    }
    
    // Get Component In Children
    public abstract partial class Behaviour
    {
        public Component GetComponentInChildren(Type type, bool includeSelf = false)
        {
            return GetComponentInChildrenInternal(type, includeSelf);
        }

        public T GetComponentInChildren<T>(bool includeSelf = false) where T : Component
        {
            return GetComponentInChildrenInternal(typeof(T), includeSelf) as T;
        }
        
        internal Component GetComponentInChildrenInternal(Type type, bool includeSelf = false)
        {
            // Invalid Component
            if (type == null || GameObject == null)
                return null;
            
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");
            
            // For Each Child In GameObject
            foreach (var child in GameObject.Transform.GetChildrenRecursive(includeSelf))
            {
                // For Each Component In Child
                foreach (var component in child.GameObject.Components)
                {
                    if (type.IsAssignableFrom(component.GetType()))
                    {
                        return component;
                    }
                }
            }

            return null;
        }
    }
    
    // Get Components
    public abstract partial class Behaviour
    {
        public Component[] GetComponentsInChildren(Type type, bool includeSelf = false)
        {
            return GetComponentsInChildrenInternal(type, includeSelf).ToArray();
        }

        public T[] GetComponentsInChildren<T>(bool includeSelf = false) where T : Component
        {
            return GetComponentsInChildrenInternal(typeof(T), includeSelf).Cast<T>().ToArray();
        }
        
        internal Component[] GetComponentsInChildrenInternal(Type type, bool includeSelf = false)
        {
            // Invalid Component
            if (type == null || GameObject == null)
                return Array.Empty<Component>();
            
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");

            // Create Results
            var results = new List<Component>();
            
            // For Each Child In GameObject
            foreach (var child in GameObject.Transform.GetChildrenRecursive(includeSelf))
            {
                // For Each Component In Child
                foreach (var component in child.GameObject.Components)
                {
                    if (type.IsAssignableFrom(component.GetType()))
                    {
                        results.Add(component);
                    }
                }
            }

            return results.ToArray();
        }
    }
    
    // Get Component Count
    public abstract partial class Behaviour
    {
        public int GetComponentCount()
        {
            return GetComponentCountInternal(typeof(Component));
        }
        
        public int GetComponentCount(Type type)
        {
            return GetComponentCountInternal(type);
        }

        public int GetComponentCount<T>() where T : Component
        {
            return GetComponentCountInternal(typeof(T));
        }
        
        internal int GetComponentCountInternal(Type type)
        {
            // Invalid Component
            if (type == null || GameObject == null)
                return 0;
            
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");

            int result = 0;
            
            // For Each Component In GameObject
            foreach (var component in GameObject.Components)
            {
                if (type.IsAssignableFrom(component.GetType()))
                {
                    result += 1;
                }
            }

            return result;
        }
    }
    
    // Get Component Index
    public abstract partial class Behaviour
    {
        public int GetComponentIndex(Type type)
        {
            return GetComponentIndexInternal(type);
        }

        public int GetComponentIndex<T>() where T : Component
        {
            return GetComponentIndexInternal(typeof(T));
        }
        
        internal int GetComponentIndexInternal(Type type)
        {
            // Invalid Component
            if (type == null || GameObject == null)
                return -1;
            
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");

            // For Each Component In GameObject
            for(int i=0; i<GameObject.Components.Count; i++)
            {
                if (type.IsAssignableFrom(GameObject.Components[i].GetType()))
                {
                    return i;
                }
            }

            return -1;
        }
    }
    
    // Get Component At Index
    public abstract partial class Behaviour
    {
        public Component GetComponentAtIndex(int index)
        {
            return GetComponentAtIndexInternal(typeof(Component), index);
        }

        public T GetComponentAtIndex<T>(int index) where T : Component
        {
            return GetComponentAtIndexInternal(typeof(T), index) as T;
        }
        
        internal Component GetComponentAtIndexInternal(Type type, int index)
        {
            // Invalid Component
            if (type == null || GameObject == null)
                return null;
            
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");

            // Get Component
            if (index >= 0 && index < GameObject.Components.Count)
            {
                var result = GameObject.Components[index];

                if (type.IsAssignableFrom(result.GetType()))
                {
                    return result;
                }
            }

            return null;
        }
    }
    
    // Try & Get Component
    public abstract partial class Behaviour
    {
        public bool TryGetComponent(Type type, out Component component)
        {
            return TryGetComponentInternal(type, out component);
        }

        public bool TryGetComponent<T>(out T component) where T : Component
        {
            if(TryGetComponentInternal(typeof(T), out var c))
            {
                component = c as T;
                return true;
            }

            component = null;
            return false;
        }
        
        internal bool TryGetComponentInternal(Type type, out Component component)
        {
            // Invalid
            component = null;
            
            // Invalid Component
            if (type == null || GameObject == null)
                return false;

            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");
            
            // For Each Component In GameObject
            foreach (var c in GameObject.Components)
            {
                if (type.IsAssignableFrom(c.GetType()))
                {
                    component = c;
                    return true;
                }
            }

            return false;
        }
    }
    
    // Has Component
    public abstract partial class Behaviour
    {
        public bool HasComponent(Component component)
        {
            return HasComponentInternal(component);
        }
        
        public bool HasComponent(Type type)
        {
            return HasComponentInternal(GetComponent(type));
        }
        
        public bool HasComponent<T>() where T : Component
        {
            return HasComponentInternal(GetComponent<T>());
        }

        internal bool HasComponentInternal<T>(T component) where T : Component
        {
            // Invalid Component
            if (component == null || GameObject == null)
                return false;
            
            // Component Type
            var type = component.GetType();
            
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");
            
            // For Each Component In GameObject
            foreach (var c in GameObject.Components)
            {
                if (c == component)
                {
                    return true;
                }
            }

            return false;
        }
    }

    // Destroy Component
    public abstract partial class Behaviour
    {
        internal bool DestroyComponent(Component component)
        {
            return DestroyComponentInternal(component);
        }
        
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
            if (component == null || GameObject == null)
                return false;
            
            // Component Type
            var type = component.GetType();
            
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");

            // Check For Component Instance
            if (HasComponent(component))
            {
                // Require Component
                if (!GameObject.IsDestroying())
                {
                    // For Each Component
                    foreach (var checkComponent in GameObject.Components)
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
                // Debug.Log($"Component '{type.Name}' destroy on GameObject '{GameObject.Name}'");
                GameObject.Components.Remove(component);
                return true;
            }

            return false;
        }
    }
}